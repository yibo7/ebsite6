//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Configuration;
//using System.Web.SessionState;
//using ServiceStack.Redis;
//using ServiceStack.Redis.Support.Locking;

//namespace EbSite.Core.EbSession
//{
//    public sealed class EbSessionStateStoreProvider:SessionStateStoreProviderBase
//    {
//        private static IRedisClientsManager clientManagerStatic;
//        private static EbSessionStateStoreOptions options;
//        private static object locker = new object();

//        private readonly Func<HttpContext, HttpStaticObjectsCollection> staticObjectsGetter;
//        private IRedisClientsManager clientManager;
//        private bool manageClientManagerLifetime;
//        private string name;

//        private int sessionTimeoutMinutes;

//        /// <summary>
//        /// Gets the client manager for the provider.
//        /// </summary>
//        public IRedisClientsManager ClientManager { get { return clientManager; } }

//        internal EbSessionStateStoreProvider(Func<HttpContext, HttpStaticObjectsCollection> staticObjectsGetter)
//        {
//            this.staticObjectsGetter = staticObjectsGetter;
//        }

//        public EbSessionStateStoreProvider()
//        {
//            staticObjectsGetter = ctx => SessionStateUtility.GetSessionStaticObjects(ctx);
//        }

//        /// <summary>
//        /// Sets the client manager to be used for the session state provider. 
//        /// This client manager's lifetime will not be managed by the RedisSessionStateProvider.
//        /// However, if this is not set, a client manager will be created and
//        /// managed by the RedisSessionStateProvider.
//        /// </summary>
//        /// <param name="clientManager"></param>
//        public static void SetClientManager(IRedisClientsManager clientManager)
//        {
//            if (clientManager == null) throw new ArgumentNullException();
//            if (clientManagerStatic != null)
//            {
//                throw new InvalidOperationException("The client manager can only be configured once.");
//            }
//            clientManagerStatic = clientManager;
//        }

//        public static void SetOptions(EbSessionStateStoreOptions options)
//        {
//            if (options == null) throw new ArgumentNullException("options");
//            if (EbSessionStateStoreProvider.options != null)
//            {
//                throw new InvalidOperationException("选项已经配置.");
//            }

//            // Clone so that we don't allow references to be modified once 
//            // configured.
//            EbSessionStateStoreProvider.options = new EbSessionStateStoreOptions(options);
//        }

//        internal static void ResetClientManager()
//        {
//            clientManagerStatic = null;
//        }

//        internal static void ResetOptions()
//        {
//            options = null;
//        }
//        /// <summary>
//        /// 初始化
//        /// </summary>
//        /// <param name="name">名字</param>
//        /// <param name="config">配置集合</param>
//        public override void Initialize(string name, NameValueCollection config)
//        {
//            if (String.IsNullOrWhiteSpace(name))
//            {
//                name = "AspNetSession";
//            }

//            this.name = name;
            
//            var sessionConfig = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");

//            sessionTimeoutMinutes = (int)sessionConfig.Timeout.TotalMinutes;

//            lock (locker)
//            {
//                if (options == null)
//                {
//                    SetOptions(new EbSessionStateStoreOptions());
//                }

//                if (clientManagerStatic == null)
//                {
//                    var host = config["host"];
//                    var clientType = config["clientType"];

//                    clientManager = CreateClientManager(clientType, host);
//                    manageClientManagerLifetime = true;
//                }
//                else
//                {
//                    clientManager = clientManagerStatic;
//                    manageClientManagerLifetime = false;
//                }
//            }

//            base.Initialize(name, config);
//        }

//        private IRedisClientsManager CreateClientManager(string clientType, string host)
//        {
//            if (String.IsNullOrWhiteSpace(host))
//            {
//                host = "localhost:6379";
//            }

//            if (String.IsNullOrWhiteSpace(clientType))
//            {
//                clientType = "POOLED";
//            }

//            if (clientType.ToUpper() == "POOLED")
//            {
//                return new PooledRedisClientManager(host);
//            }
//            else
//            {
//                return new BasicRedisClientManager(host);
//            }
//        }

//        private IRedisClient GetClient()
//        {
//            return clientManager.GetClient();
//        }
        
//        /// <summary>
//        /// Create a distributed lock for cases where more-than-a-transaction
//        /// is used but we need to prevent another request from modifying the
//        /// session. For example, if we need to get the session, mutate it and
//        /// then write it back. We can't use *just* a transaction for this 
//        /// approach because the data is returned with the rest of the commands!
//        /// </summary>
//        /// <param name="client"></param>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        private DisposableDistributedLock GetDistributedLock(IRedisClient client, string key)
//        {
//            var lockKey = key + options.KeySeparator + "lock";
//            return new DisposableDistributedLock(
//                client, lockKey, 
//                options.DistributedLockAcquisitionTimeoutSeconds.Value, 
//                options.DistributedLockTimeoutSeconds.Value
//            );
//        }

//        private string GetSessionIdKey(string id)
//        {
//            return name + options.KeySeparator + id;
//        }

//        public override void CreateUninitializedItem(HttpContext context, string id, int timeout)
//        {
//            /*
             
//            获取当前请求的 HttpContext、当前请求的 SessionID，以及当前请求的锁定标识符并通过把 actionFlags 参数值设置成 InitializeItem 
//            的方式在会话数据存储中添加一个未被初始化的项。 

//            在 regenerateExpiredSessionId 参数被设置成 true 的时候，CreateUninitializedItem 方法会与无 Cookie 会话一起被使用，
//            从而导致 SessionStateModule 在遇到一个已过期的 SessionID 的时候会重新生成一个新的 SessionID 值。 

//            生成新 SessionID 值的进程需要浏览器被重定向到一个包含有生成了更新的 SessionID 的 URL。CreateUninitializedItem 
//            方法在包含已过期 SessionID 的请求的初始化期间被调用。在 SessionStateModule 获得一个新的 SessionID 值并替换已过期的 SessionID 之后，
//            它会调用 CreateUninitializedItem 方法为会话状态数据存储添加一个未被初始化的会话项。然后浏览器被重定向到包含生成了更新的 SessionID 值的 URL。
//            会话数据存储中现有的未初始化会话项会确保在包括生成了更新的 SessionID 值并且没有出现错误的被重定向的请求的情况下会被替代为或被视为一个新的会话。 

//            会话数据存储中未被初始化的项与生成了更新的 SessionID 相关联，并且只包含了默认值，包括期限日期和时间，以及一个与 GetItem 和 GetItemExclusive 方法的 actionFlags 参数相对应的值。
//            会话状态存储中未被初始化的项应该在 actionFlags 参数中包括一个 InitializeItem 枚举值（1）。这个值通过 GetItem 和 GetItemExclusive 方法被传递到 SessionStateModule 并通知 SessionStateModule 
//            当前会话是一个新的会话。SessionStateModule 然后将初始化这个新的会话并引发 Session_OnStart 事件。            
             
             
//             */

//            var key = GetSessionIdKey(id);
//            using (var client = GetClient())
//            {
//                var state = new EbSessionStateEntity()
//                {
//                    Timeout = timeout,
//                    Flags = SessionStateActions.InitializeItem
//                };

//                UpdateSessionState(client, key, state);
//            }
//        }

//        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
//        {
//            /*
             
//             获取当前请求的 HttpContext 和当前会话的 Timeout 属性并返回一个拥有空的 ISessionStateItemCollection 对象、HttpStaticObjectsCollection 集合，
//             以及被指定的 Timeout 值的全新 SessionStateStoreData 对象。
//             ASP.NET 应用程序的HttpStaticObjectsCollection 集合能够通过调用 GetSessionStaticObjects 方法来获取。 
             
//             */
//            return new SessionStateStoreData(new SessionStateItemCollection(),
//               staticObjectsGetter(context),
//               timeout);
//        }
//        /// <summary>
//        /// 获取当前请求的 HttpContext 并通过会话状态存储提供者来完成任何必需的初始化任务。 
//        /// </summary>
//        /// <param name="context"></param>
//        public override void InitializeRequest(HttpContext context)
//        {
            
//        }
//        /// <summary>
//        /// 获取当前请求的 HttpContext 并通过会话状态存储提供者来完成任何必需的清理任务。
//        /// </summary>
//        /// <param name="context"></param>
//        public override void EndRequest(HttpContext context)
//        {
            
//        }

//        private void UseTransaction(IRedisClient client, Action<IRedisTransaction> action)
//        {
//            using (var transaction = client.CreateTransaction())
//            {
//                action(transaction);
//                transaction.Commit();
//            }
//        }

//        public override void ResetItemTimeout(HttpContext context, string id)
//        {
//            var key = GetSessionIdKey(id);
//            using (var client = GetClient())
//            {
//                UseTransaction(client, transaction =>
//                {
//                    transaction.QueueCommand(c => c.ExpireEntryIn(key, TimeSpan.FromMinutes(sessionTimeoutMinutes)));
//                });
//            };
//        }

//        public override void RemoveItem(HttpContext context, string id, object lockId, SessionStateStoreData item)
//        {
//            /*
             
//              获取当前请求的 HttpContext、当前请求的 SessionID，以及当前请求的锁定标识符并在数据存储项与被提供的 SessionID、当前应用程序，
//              以及被提供的锁定标识符相匹配的时候从数据存储中删除会话信息。这个方法在 Abandon 方法被调用的时候被调用。
             
//             */
//            var key = GetSessionIdKey(id);
//            using (var client = GetClient())
//            using (var distributedLock = GetDistributedLock(client, key))
//            {
//                if (distributedLock.LockState == DistributedLock.LOCK_NOT_ACQUIRED)
//                {
//                    options.OnDistributedLockNotAcquired(id);
//                    return;
//                }

//                var stateRaw = client.GetAllEntriesFromHashRaw(key);

//                UseTransaction(client, transaction =>
//                {
//                    EbSessionStateEntity state;
//                    if (EbSessionStateEntity.TryParse(stateRaw, out state) && state.Locked && state.LockId == (int)lockId)
//                    {
//                        transaction.QueueCommand(c => c.Remove(key));
//                    }
//                });
//            }
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="context"></param>
//        /// <param name="id"></param>
//        /// <param name="locked"></param>
//        /// <param name="lockAge"></param>
//        /// <param name="lockId"></param>
//        /// <param name="actions"></param>
//        /// <returns></returns>
//        public override SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
//        {
//            /*
//             获取当前请求的 HttpContext 和当前请求的 SessionID。从会话数据存储中获取会话值和信息并在请求期间锁定数据存储中的会话项数据。
//             * GetItemExclusive 方法设置了几个输出参数的值来通知对 SessionStateModule 方法（与数据存储中当前会话状态项的状态相关）的调用。 
//                如果没有在数据存储中找到任何会话项数据，GetItemExclusive 方法就会把被锁定的输出参数设置成 false 并返回 null。
//             * 这将导致 SessionStateModule 为该请求调用 CreateNewStoreData 方法来创建一个新的 SessionStateStoreData 对象。 
//                如果在数据存储中找到了会话项数据但是数据已经被锁定，GetItemExclusive 方法会把被锁定的输出参数设置成 true，
//             * 在会话项被锁定的时候把 lockAge 输出参数设置成当前日期和时间与被锁定的时期和时间的和，
//             * 把 lockId 参数设置成需要锁定的从数据存储中被获取的标识符，并返回 null。
//             * 这会导致 SessionStateModule 在半秒的时间间隔之后再次调用 GetItemExclusive 方法来尝试获取该会话项信息并获得对数据的锁定。
//             * 如果 lockAge 输出参数中所设置的值超出了 ExecutionTimeout 属性中的上限，那么 SessionStateModule 将会调用 ReleaseItemExclusive 
//             * 方法来清除对会话项数据的锁定然后再次调用 GetItemExclusive 方法。 actionFlags 参数会在 regenerateExpiredSessionId 参数被设置成 true 的时候与无 Cookie 会话一起被使用。
//             * 在 actionFlags 参数的值被设置成 InitializeItem（1）的时候表示会话数据存储中的该项是一个需要进行初始化的新会话。
//             * 那么会话数据存储中未被初始化的项将通过调用 CreateUninitializedItem 方法而被创建。如果会话数据存储中的项是未被初始化的，那么 actionFlags 参数将被设置成 0。 
//                如果你提供了对无 Cookie 会话的支持，那么你应该为当前会话项而把 actionFlags 输出参数设置成从会话数据存储中被返回的值。
//             * 如果被请求会话存储项的 actionFlags 参数值等于 InitializeItem 枚举值（1），那么 GetItemExclusive 方法就应该在 actionFlags 输出参数被设置之后把数据存储中的值设置成 0。 

//             */
//            return GetItem(true, context, id, out locked, out lockAge, out lockId, out actions);
//        }

//        public override SessionStateStoreData GetItem(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
//        {
//            /*
//             这个方法完成与 GetItemExclusive 方法相同的工作，区别就是它不会尝试获取对数据存储中的会话项进行锁定。GetItem 方法就会在 EnableSessionState 参数被设置成 ReadOnly 的时候被调用。 
//             */
//            return GetItem(false, context, id, out locked, out lockAge, out lockId, out actions);
//        }
//        private SessionStateStoreData GetItem(bool isExclusive, HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
//        {
//            /*
//             这个方法完成与 GetItemExclusive 方法相同的工作，区别就是它不会尝试获取对数据存储中的会话项进行锁定。GetItem 方法就会在 EnableSessionState 参数被设置成 ReadOnly 的时候被调用。 
//             */
//            locked = false;
//            lockAge = TimeSpan.Zero;
//            lockId = null;
//            actions = SessionStateActions.None;
//            SessionStateStoreData result = null;

//            var key = GetSessionIdKey(id);
//            using (var client = GetClient())
//            using (var distributedLock = GetDistributedLock(client, key))
//            {
//                if (distributedLock.LockState == DistributedLock.LOCK_NOT_ACQUIRED)
//                {
//                    options.OnDistributedLockNotAcquired(id);
//                    return null;
//                }
                 
//                var stateRaw = client.GetAllEntriesFromHashRaw(key);

//                EbSessionStateEntity state;
//                if (!EbSessionStateEntity.TryParse(stateRaw, out state))
//                {
//                    return null;
//                }

//                actions = state.Flags;

//                if (state.Locked)
//                {
//                    locked = true;
//                    lockId = state.LockId;
//                    lockAge = DateTime.UtcNow - state.LockDate;
//                    return null;
//                }

//                if (isExclusive)
//                {
//                    locked = state.Locked = true;
//                    state.LockDate = DateTime.UtcNow;
//                    lockAge = TimeSpan.Zero;
//                    lockId = ++state.LockId;
//                }

//                state.Flags = SessionStateActions.None;

//                UseTransaction(client, transaction =>
//                {
//                    transaction.QueueCommand(c => c.SetRangeInHashRaw(key, state.ToMap()));
//                    transaction.QueueCommand(c => c.ExpireEntryIn(key, TimeSpan.FromMinutes(state.Timeout)));
//                });

//                var items = actions == SessionStateActions.InitializeItem ? new SessionStateItemCollection() : state.Items;

//                result = new SessionStateStoreData(items, staticObjectsGetter(context), state.Timeout);
//            }

//            return result;
//        }

//        public override void ReleaseItemExclusive(HttpContext context, string id, object lockId)
//        {
//            /*
             
//             获取当前请求的 HttpContext、当前请求的 SessionID，以及当前请求的锁定标识符并释放对于会话数据存储项的锁定。
//             这个方法在 GetItem 或 GetItemExclusive 方法被调用并且数据存储所指定的被请求项已经被锁定，但是锁定时间已经超出了 ExecutionTimeout 的时候才会被调用。
//             锁定通过这个方法被清除，并释放会话项以用于其他请求。 
             
//             */
//            using (var client = GetClient())
//            {
//                UpdateSessionStateIfLocked(client, id, (int)lockId, state =>
//                {
//                    state.Locked = false;
//                    state.Timeout = sessionTimeoutMinutes;
//                });
//            }
//        }

//        public override void SetAndReleaseItemExclusive(HttpContext context, string id, SessionStateStoreData item, object lockId, bool newItem)
//        {
//            /*             
//             获取当前请求的 HttpContext、当前请求的 SessionID、包含被存储的会话值的 SessionStateStoreData 对象、当前请求的锁定标识符，
//             以及表示被存储的数据是否属于新的会话还是现有会话的值。 
//            如果 newItem 参数被设置成 true，那么 SetAndReleaseItemExclusive 方法就会使用被提供的值在数据存储中插入一个新项。
//            否则，则会使用被提供的值来更新数据存储中的现有项，并且对于数据的锁定也将被释放。只有与被提供的 SessionID 和锁定标识符的值相匹配的当前应用程序会话数据才会被更新。 
//            在 SetAndReleaseItemExclusive 方法被调用之后，会通过 SessionStateModule 来调用 ResetItemTimeout 方法以更新会话项数据的过期日期和时间。              
//             */
//            using (var client = GetClient())
//            {
//                if (newItem)
//                {
//                    var state = new EbSessionStateEntity()
//                    {
//                        Items = (SessionStateItemCollection)item.Items,
//                        Timeout = item.Timeout,
//                    };

//                    var key = GetSessionIdKey(id);
//                    UpdateSessionState(client, key, state);
//                }
//                else
//                {
//                    UpdateSessionStateIfLocked(client, id, (int)lockId, state =>
//                    {
//                        state.Items = (SessionStateItemCollection)item.Items;
//                        state.Locked = false;
//                        state.Timeout = item.Timeout;
//                    });
//                }
//            }
//        }

//        private void UpdateSessionStateIfLocked(IRedisClient client, string id, int lockId, Action<EbSessionStateEntity> stateAction)
//        {
//            var key = GetSessionIdKey(id);
//            using (var distributedLock = GetDistributedLock(client, key))
//            {
//                if (distributedLock.LockState == DistributedLock.LOCK_NOT_ACQUIRED)
//                {
//                    options.OnDistributedLockNotAcquired(id);
//                    return;
//                }

//                var stateRaw = client.GetAllEntriesFromHashRaw(key);
//                EbSessionStateEntity state;
//                if (EbSessionStateEntity.TryParse(stateRaw, out state) && state.Locked && state.LockId == lockId)
//                {
//                    stateAction(state);
//                    UpdateSessionState(client, key, state);
//                }
//            }
//        }

//        private void UpdateSessionState(IRedisClient client, string key, EbSessionStateEntity state)
//        {
//            UseTransaction(client, transaction =>
//            {
//                transaction.QueueCommand(c => c.SetRangeInHashRaw(key, state.ToMap()));
//                transaction.QueueCommand(c => c.ExpireEntryIn(key, TimeSpan.FromMinutes(state.Timeout)));
//            });
//        }
//        /// <summary>
//        /// 设置session过期回调方法.
//        /// </summary>
//        /// <param name="expireCallback"></param>
//        /// <returns></returns>
//        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
//        {
//            /*
//             获取被定义在 Global.asax 文件中并对 Session_OnEnd 事件进行引用的事件代表。
//             * 如果会话状态存储提供者支持 Session_OnEnd 事件，那么将设置一个对于 SessionStateItemExpireCallback 参数的局部引用并通过该方法返回 true；
//             * 否则，该方法返回 false。 
//             */
//            // Redis < 2.8 doesn't easily support key expiry notifications.
//            // As of Redis 2.8, keyspace notifications (http://redis.io/topics/notifications)
//            // can be used. Therefore, if you'd like to support the expiry
//            // callback and are using Redis 2.8, you can inherit from this
//            // class and implement it.
//            return false;
//        }
//        /// <summary>
//        /// 释放Session
//        /// </summary>
//        public override void Dispose()
//        {
//            if (manageClientManagerLifetime)
//            {
//                clientManager.Dispose();
//            }
//        }
//    }
//}
