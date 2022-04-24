DROP PROCEDURE IF EXISTS EB_AddPermissionToRole;

CREATE  PROCEDURE EB_AddPermissionToRole(p_RoleID int,p_PermissionID int)
begin
	DECLARE p_Count int;
	set p_Count=(SELECT Count(PermissionID) FROM EB_Admin_RolesPermissions WHERE RoleID = p_RoleID and PermissionID = p_PermissionID);
	IF p_Count =0 THEN
			INSERT INTO EB_Admin_RolesPermissions(RoleID, PermissionID) VALUES(p_RoleID, p_PermissionID);
	end if;
end;



DROP PROCEDURE IF EXISTS EB_AddSearchWord;

CREATE  PROCEDURE EB_AddSearchWord(p_ID CHAR(36),p_KeyWord VARCHAR(200))
BEGIN
	DECLARE p_Count int;
  set p_Count = (SELECT COUNT(id)  FROM eb_searchword WHERE keyword =p_KeyWord);
  if p_Count=0 THEN

	INSERT INTO eb_searchword(id, keyword,searchcount,addtime) VALUES(p_ID, p_KeyWord,p_Count+1, now());
  ELSE
	    UPDATE eb_searchword SET searchcount=searchcount+1,addtime= now()  WHERE keyword=p_KeyWord;
  end if;
	  
END;



DROP PROCEDURE IF EXISTS EB_AddUserToRole;

CREATE  PROCEDURE EB_AddUserToRole(p_UserID int,p_RoleID int)
begin
	DECLARE p_Count int;
  set p_Count=(SELECT Count(UserID) FROM EB_Admin_UserRoles WHERE RoleID = p_RoleID AND UserID = p_UserID);
IF p_Count = 0 then
		INSERT INTO EB_Admin_UserRoles(UserID, RoleID) VALUES(p_UserID, p_RoleID);
  end if;
end;

DROP PROCEDURE IF EXISTS EB_UploadIsGood;

CREATE  PROCEDURE EB_UploadIsGood(p_ID int)
begin
	UPDATE EB_NewsContent SET isgood = ABS(isgood-1) WHERE ID=p_ID;
end;



DROP PROCEDURE IF EXISTS EB_UploadIsGood;

CREATE  PROCEDURE EB_UploadIsGood(p_ID int)
begin
	UPDATE EB_NewsContent SET isgood = ABS(isgood-1) WHERE ID=p_ID;
end;

DROP PROCEDURE IF EXISTS EB_UpdateUser;

CREATE  PROCEDURE EB_UpdateUser(p_UserName varchar(50),
p_IsLock bit,
p_LastLoginTime date,
p_UserID int,
p_CurrentSiteID int)
begin
	UPDATE EB_Admin_User SET
		UserName = p_UserName,
		IsLock = p_IsLock,
		LastLoginTime = p_LastLoginTime,
		CurrentSiteID = p_CurrentSiteID		
	WHERE UserID = p_UserID;
end;

DROP PROCEDURE IF EXISTS EB_UpdateRole;

CREATE  PROCEDURE EB_UpdateRole(p_RoleID int,p_Description varchar(50))
begin
	UPDATE EB_Admin_Roles SET Description = p_Description WHERE RoleID = p_RoleID;
end;



DROP PROCEDURE IF EXISTS EB_RemoveUserFromRole;

CREATE  PROCEDURE EB_RemoveUserFromRole(p_UserID int,p_RoleID int)
begin
	DELETE from EB_Admin_UserRoles WHERE UserID = p_UserID AND RoleID = p_RoleID;
end;

DROP PROCEDURE IF EXISTS EB_RemovePermissionFromRole;

CREATE  PROCEDURE EB_RemovePermissionFromRole(p_RoleID int,p_PermissionID int)
begin
	DELETE FROM EB_Admin_RolesPermissions WHERE RoleID = p_RoleID and PermissionID = p_PermissionID;
end;

DROP PROCEDURE IF EXISTS EB_GetUsers;

CREATE  PROCEDURE EB_GetUsers(p_key varchar(50))
begin
SELECT * FROM EB_Admin_User where UserName like CONCAT('%',p_key,'%') order by UserID;
end;



DROP PROCEDURE IF EXISTS EB_GetRoleDetails;

CREATE  PROCEDURE EB_GetRoleDetails(p_RoleID int)
begin
	SELECT RoleID, Description FROM EB_Admin_Roles WHERE RoleID = p_RoleID;
end;



DROP PROCEDURE IF EXISTS EB_GetUserDetails;

CREATE  PROCEDURE EB_GetUserDetails(p_UserID int)
begin
	SELECT * FROM EB_Admin_User WHERE UserID = p_UserID;
end;



DROP PROCEDURE IF EXISTS EB_GetUserDetailsByUserName;

CREATE  PROCEDURE EB_GetUserDetailsByUserName(p_UserName varchar(50))
begin
	SELECT * FROM EB_Admin_User WHERE UserName = p_UserName;
end;



DROP PROCEDURE IF EXISTS EB_GetUserRoles;

CREATE  PROCEDURE EB_GetUserRoles(p_UserID int)
begin
	SELECT ur.RoleID, r.Description FROM EB_Admin_UserRoles ur INNER JOIN EB_Admin_Roles r ON ur.RoleID = r.RoleID  WHERE ur.UserID = p_UserID;
end;




DROP PROCEDURE IF EXISTS EB_DeleteUser;

CREATE  PROCEDURE EB_DeleteUser(p_UserID int)
BEGIN
start TRANSACTION;
DELETE FROM EB_Admin_UserRoles WHERE UserId = p_UserID;
DELETE FROM EB_Admin_User WHERE UserId = p_UserID;
COMMIT;
end;



DROP PROCEDURE IF EXISTS EB_GetAllRoles;

CREATE  PROCEDURE EB_GetAllRoles()
begin
	SELECT RoleID,Description FROM EB_Admin_Roles ORDER BY Description ASC;
end;



DROP PROCEDURE IF EXISTS EB_GetEffectivePermissionList;

CREATE  PROCEDURE EB_GetEffectivePermissionList(p_UserID int)
BEGIN
   SELECT DISTINCT EB_Admin_Permissions.Description FROM EB_Admin_RolesPermissions inner join EB_Admin_Permissions on EB_Admin_RolesPermissions.PermissionID=EB_Admin_Permissions.PermissionID WHERE RoleID IN(SELECT RoleID FROM EB_Admin_UserRoles WHERE UserID = p_UserID);
end;



DROP PROCEDURE IF EXISTS EB_GetEffectivePermissionListID;

CREATE  PROCEDURE EB_GetEffectivePermissionListID(p_UserID int)
begin
   SELECT DISTINCT EB_Admin_Permissions.PermissionID FROM EB_Admin_RolesPermissions inner join EB_Admin_Permissions on EB_Admin_RolesPermissions.PermissionID=EB_Admin_Permissions.PermissionID WHERE RoleID IN(SELECT RoleID FROM EB_Admin_UserRoles WHERE UserID = p_UserID);
end;



DROP PROCEDURE IF EXISTS EB_GetPermissionDetails;

CREATE  PROCEDURE EB_GetPermissionDetails(p_PermissionID int)
begin
	SELECT * FROM EB_Admin_Permissions WHERE PermissionID = p_PermissionID;
end;



DROP PROCEDURE IF EXISTS EB_CreatePermission;

CREATE  PROCEDURE EB_CreatePermission(p_CategoryID int,p_Description varchar(50))
begin
	INSERT INTO EB_Admin_Permissions(CategoryID,Description) VALUES(p_CategoryID,p_Description);
	SELECT @@IDENTITY;
end;



DROP PROCEDURE IF EXISTS EB_CreateRole;

CREATE  PROCEDURE EB_CreateRole(p_Description varchar(50))
BEGIN
	INSERT INTO EB_Admin_Roles(Description) VALUES(p_Description);
	SELECT @@IDENTITY;
end;



DROP PROCEDURE IF EXISTS EB_CreateUser;

CREATE  PROCEDURE EB_CreateUser(p_UserID int,p_UserName VARCHAR(100))
BEGIN
	INSERT INTO EB_Admin_User(UserID,UserName,isLock,LastLoginTime,CurrentSiteID) VALUES(p_UserID,p_UserName,0,NOW(),1);
	
  SET p_UserID =@@session.identity;
	SELECT 1;
end;



DROP PROCEDURE IF EXISTS EB_DeletePermission;

CREATE PROCEDURE EB_DeletePermission(p_PermissionID int)
begin
	START TRANSACTION;
		DELETE from EB_Admin_Permissions WHERE PermissionID = p_PermissionID;
		DELETE from EB_Admin_RolesPermissions WHERE PermissionID = p_PermissionID;
	COMMIT;
end;



DROP PROCEDURE IF EXISTS EB_DeleteRole;

CREATE  PROCEDURE EB_DeleteRole(p_RoleID int)
begin
	START TRANSACTION;
		DELETE FROM EB_Admin_RolesPermissions WHERE RoleID = p_RoleID;
		DELETE FROM EB_Admin_UserRoles WHERE RoleID = p_RoleID;
		DELETE FROM EB_Admin_Roles WHERE RoleID = p_RoleID;
	COMMIT;
end;







DROP PROCEDURE IF EXISTS EB_GetPermissionList;

CREATE  PROCEDURE EB_GetPermissionList(p_RoleID int)
begin
	IF p_RoleID IS NULL then
		SELECT PermissionID, Description, CategoryID FROM EB_Admin_Permissions ORDER BY Description;
	ELSE
		SELECT ap.PermissionID, ap.Description, ap.CategoryID FROM EB_Admin_Permissions ap INNER JOIN
		EB_Admin_RolesPermissions apr ON ap.PermissionID = apr.PermissionID WHERE
		apr.RoleID = p_RoleID ORDER BY ap.Description;
	end if;
end;



DROP PROCEDURE IF EXISTS EB_GetRelatedList;

CREATE  PROCEDURE EB_GetRelatedList(p_bid int,p_top int,p_count int,p_siteid int)
begin
  if(p_count>0) THEN
  create temporary table tmp_artice_tb select id,HtmlName,NewsTitle,ContentInfo,AddTime FROM eb_newscontent where ClassID =p_bid and SiteID=p_siteid order by id desc limit p_count;
else 
  create temporary table tmp_artice_tb select id,HtmlName,NewsTitle,ContentInfo,AddTime FROM eb_newscontent where ClassID =p_bid and SiteID=p_siteid order by id desc LIMIT 1000 ;
END IF;
	SELECT * from tmp_artice_tb ORDER BY RAND() limit p_top;
	DROP temporary table tmp_artice_tb;
end;



DROP PROCEDURE IF EXISTS EB_IsFriend;
CREATE  PROCEDURE EB_IsFriend(p_UserID int,p_FriendID int)
BEGIN
DECLARE ishave int;
DECLARE ishave2 int;
DECLARE ishave3 int;
set ishave=(select count(1) from eb_friendList where UserID=p_UserID and FriendID=p_FriendID and IsAllow=1);
set ishave2=(select count(1) from eb_friendList where UserID=p_UserID and FriendID=p_FriendID );
set ishave3=(select count(1) from eb_friendList where UserID=p_FriendID and FriendID=p_UserID );
if(ishave>0)THEN
 SELECT 1;
ELSEIF(ishave2>0) THEN
 SELECT 2;
ELSEIF(ishave3>0) THEN
 SELECT 3;
ELSE
 SELECT 0;
end IF;

END;





DROP PROCEDURE IF EXISTS EB_ProcGetSubIDs;

CREATE  PROCEDURE EB_ProcGetSubIDs(p_ParentID INT,p_SiteID int)
begin  


      DECLARE sTemp VARCHAR(10000); 
      DECLARE sTempChd VARCHAR(10000); 
     
       SET sTemp = cast(p_ParentID as CHAR); 
      SET sTempChd =cast(p_ParentID as CHAR); 
    
      WHILE sTempChd is not null DO 
         SET sTemp = concat(sTemp,',',sTempChd); 
         SELECT GROUP_CONCAT(id) INTO sTempChd FROM eb_newsclass where FIND_IN_SET(ParentID,sTempChd)>0; 
       END WHILE; 
     

   
		set @ddd =  CONCAT('SELECT  id ,ClassName,ParentID from eb_newsclass WHERE siteid=',p_SiteID,' and id in(',sTemp,');');


 
 prepare stmt4 from  @ddd;
						EXECUTE stmt4;
						deallocate prepare stmt4;

end;




DROP PROCEDURE IF EXISTS EB_ProcFoo;

CREATE  PROCEDURE EB_ProcFoo(p_ID INT,p_Orderby varchar(50))
begin  
		DECLARE	pCID int;
    DECLARE str VARCHAR (100) DEFAULT p_ID;
    DECLARE pParentID int;
		SET pParentID=(select ParentID from EB_NewsClass where ID=p_ID);   
				set str =  CONCAT(str,',',pParentID);
			   WHILE pParentID>0 DO 		 
					
					 SET pCID=pParentID;
					 SET pParentID=(select ParentID from EB_NewsClass where ID=pCID);
					 set str =  CONCAT(str,',',pParentID);
         END WHILE; 
	   
		 set @ddd =  CONCAT('SELECT  id ,ClassName,ParentID from eb_newsclass WHERE id in(',str,') order by ',p_Orderby,';');
	   prepare stmt4 from  @ddd;
						EXECUTE stmt4;
						deallocate prepare stmt4;

end;






DROP PROCEDURE IF EXISTS EB_ProcSpecialClassFoo;

CREATE  PROCEDURE EB_ProcSpecialClassFoo(p_ID INT,p_Orderby varchar(50))
begin  
		DECLARE	pCID int;
    DECLARE str VARCHAR (100) DEFAULT p_ID;
    DECLARE pParentID int;
		SET pParentID=(select ParentID from eb_specialclass where ID=p_ID);   
				set str =  CONCAT(str,',',pParentID);
			   WHILE pParentID>0 DO 		 
					
					 SET pCID=pParentID;
					 SET pParentID=(select ParentID from eb_specialclass where ID=pCID);
					 set str =  CONCAT(str,',',pParentID);
         END WHILE; 
	   
		 set @ddd =  CONCAT('SELECT  id ,specialname,ParentID from eb_specialclass WHERE id in(',str,') order by ',p_Orderby,';');
	   prepare stmt4 from  @ddd;
						EXECUTE stmt4;
						deallocate prepare stmt4;

end;




