
DROP TABLE IF EXISTS `eb_address`;
CREATE TABLE `eb_address` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `UserRealName` varchar(50) DEFAULT NULL,
  `Phone` char(20) DEFAULT NULL,
  `Mobile` char(11) DEFAULT NULL,
  `Email` char(40) DEFAULT NULL,
  `PostCode` char(6) DEFAULT NULL,
  `CountryID` int(11) DEFAULT NULL,
  `CountryName` varchar(50) DEFAULT NULL,
  `ProvinceID` int(11) DEFAULT NULL,
  `ProvinceName` varchar(50) DEFAULT NULL,
  `CityID` int(11) DEFAULT NULL,
  `CityName` varchar(50) DEFAULT NULL,
  `AreaID` int(11) DEFAULT NULL,
  `AreaName` varchar(50) DEFAULT NULL,
  `AddressInfo` varchar(300) DEFAULT NULL,
  `IsTemAdress` int(11) DEFAULT NULL,
  `AddDateime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Address_UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;



DROP TABLE IF EXISTS `eb_users`;
CREATE TABLE `eb_users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` char(40) NOT NULL DEFAULT '',
  `Password` char(32) DEFAULT NULL,
  `emailAddress` char(40) NOT NULL DEFAULT '',
  `IsApproved` tinyint(1) unsigned NOT NULL,
  `IsLockedOut` tinyint(1) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `LastLockoutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(11) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `Credits` int(10) DEFAULT NULL,
  `NiName` varchar(50) DEFAULT NULL,
  `Sign` varchar(300) DEFAULT NULL,
  `MobileNumber` char(11) DEFAULT NULL,
  `UserLevel` tinyint(2) DEFAULT NULL,
  `IP` varchar(15) DEFAULT NULL,
  `RegRemark` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`UserID`,`UserName`,`emailAddress`)
) ENGINE=InnoDB AUTO_INCREMENT=140 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_favorite`;
CREATE TABLE `eb_favorite` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ContentID` int(11) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  `FavType` int(11) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  `Title` varchar(50) DEFAULT NULL,
  `LinkUrl` varchar(200) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Tagids` varchar(100) DEFAULT NULL,
  `Annex1` varchar(50) DEFAULT NULL,
  `Annex2` varchar(50) DEFAULT NULL,
  `Annex3` varchar(50) DEFAULT NULL,
  `Annex4` int(11) DEFAULT NULL,
  `Annex5` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_emailsendpool`;
CREATE TABLE `eb_emailsendpool` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(300) DEFAULT NULL,
  `MsgBody` text,
  `SendToUserID` int(11) DEFAULT NULL,
  `SendToEmail` char(40) DEFAULT NULL,
  `AttaUrl` varchar(255) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  `AddDateTimeInc` int(11) DEFAULT NULL,
  `AddUserID` int(11) DEFAULT NULL,
  `AddUserNiName` varchar(30) DEFAULT NULL,
  `IsSended` smallint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_msg`;
CREATE TABLE `eb_msg` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Sender` varchar(50) DEFAULT NULL,
  `Recipient` varchar(50) DEFAULT NULL,
  `FolderType` tinyint(2) DEFAULT NULL,
  `IsNew` tinyint(4) DEFAULT NULL,
  `Title` longtext,
  `SendDate` datetime DEFAULT NULL,
  `MsgContent` longtext,
  `SenderNiName` varchar(50) DEFAULT NULL,
  `SenderUserID` int(11) DEFAULT NULL,
  `RecipientUserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `msg_RecipientUserID` (`RecipientUserID`)
) ENGINE=InnoDB AUTO_INCREMENT=212 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `eb_orderoptionitems`;
CREATE TABLE `eb_orderoptionitems` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderOptionID` int(11) DEFAULT NULL,
  `ItemName` varchar(100) DEFAULT NULL,
  `IsUserInputRequired` bit(1) DEFAULT NULL,
  `UserInputTitle` varchar(50) DEFAULT NULL,
  `AppendMoney` decimal(18,0) DEFAULT NULL,
  `CalculateMode` int(11) DEFAULT NULL,
  `Remark` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_orderoptions`;
CREATE TABLE `eb_orderoptions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `OptionName` varchar(100) DEFAULT NULL,
  `SelectMode` int(11) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_orderoptionvalue`;
CREATE TABLE `eb_orderoptionvalue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderId` varchar(50) DEFAULT NULL,
  `LookupListId` int(11) DEFAULT NULL,
  `LookupItemId` int(11) DEFAULT NULL,
  `ListDescription` varchar(500) DEFAULT NULL,
  `ItemDescription` varchar(500) DEFAULT NULL,
  `AdjustedPrice` decimal(18,2) DEFAULT NULL,
  `CustomerTitle` varchar(50) DEFAULT NULL,
  `CustomerDescription` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_paytypeinfo`;
CREATE TABLE `eb_paytypeinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentID` int(11) DEFAULT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `Demo` varchar(200) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_paypass`;
CREATE TABLE `eb_paypass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `Pass` varchar(100) DEFAULT NULL,
  `EndType` int(11) DEFAULT NULL,
  `Balance` decimal(10,2) DEFAULT NULL,
  `RequestBalance` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `paypass_UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_profiles`;
CREATE TABLE `eb_profiles` (
  `UniqueID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(40) DEFAULT NULL,
  `ApplicationName` varchar(50) DEFAULT NULL,
  `IsAnonymous` tinyint(4) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastUpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`UniqueID`)
) ENGINE=InnoDB AUTO_INCREMENT=1173 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_shippers`;
CREATE TABLE `eb_shippers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `IsDefault` tinyint(1) DEFAULT NULL,
  `ShipperTag` varchar(200) DEFAULT NULL,
  `ShipperName` varchar(200) DEFAULT NULL,
  `RegionId` int(11) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `CellPhone` varchar(50) DEFAULT NULL,
  `TelPhone` varchar(50) DEFAULT NULL,
  `Zipcode` varchar(50) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `ShopName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_thethirdlogincode`;
CREATE TABLE `eb_thethirdlogincode` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `username` char(40) DEFAULT NULL,
  `tokencode` varchar(80) DEFAULT NULL,
  `appname` varchar(50) DEFAULT NULL,
  `isbind` tinyint(1) DEFAULT NULL,
  `otherinfo` varchar(2000) DEFAULT NULL,
  `adddate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `thethirdlogincode_userid` (`userid`),
  KEY `thethirdlogincode_tokencode` (`tokencode`)
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_withdrawlist`;
CREATE TABLE `eb_withdrawlist` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL COMMENT '请求提现的用户ID',
  `UserName` varchar(50) DEFAULT NULL COMMENT '请求提现的用户名称',
  `RequestTime` datetime DEFAULT NULL COMMENT '请求日期时间 ',
  `Amount` decimal(10,0) DEFAULT NULL COMMENT '提现金额',
  `AccountName` varchar(50) DEFAULT NULL COMMENT '银行开始人名称，个人为姓名，公司为公司名称  ',
  `BankName` varchar(50) DEFAULT NULL COMMENT '开户银行的名称',
  `CardNumber` varchar(50) DEFAULT NULL COMMENT '开户银行账号',
  `Remark` text COMMENT '备注',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_couponitems`;
CREATE TABLE `eb_couponitems` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CouponId` int(11) DEFAULT NULL,
  `LotNumber` varchar(100) DEFAULT NULL,
  `ClaimCode` varchar(32) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `EmailAddress` varchar(150) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  ` Status` tinyint(2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ClaimCode` (`ClaimCode`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_coupons`;
CREATE TABLE `eb_coupons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CouponName` varchar(50) DEFAULT NULL,
  `EndDateTime` datetime DEFAULT NULL,
  `Amount` decimal(18,2) DEFAULT NULL,
  `DiscountPrice` decimal(18,2) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `SentCount` int(11) DEFAULT NULL,
  `UsedCount` int(11) DEFAULT NULL,
  `NeedPoint` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_favoriteclass`;
CREATE TABLE `eb_favoriteclass` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(80) DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `ParentID` int(11) DEFAULT NULL,
  `Annex1` varchar(50) DEFAULT NULL,
  `Annex2` varchar(50) DEFAULT NULL,
  `Annex3` varchar(50) DEFAULT NULL,
  `Annex4` int(11) DEFAULT NULL,
  `Annex5` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

DROP TABLE IF EXISTS `eb_errinfo`;
CREATE TABLE `eb_errinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(200) DEFAULT NULL,
  `ErrMsg` varchar(5000) DEFAULT NULL,
  `ErrCount` int(11) DEFAULT NULL,
  `IsSys` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_accountmoneylog`;
CREATE TABLE `eb_accountmoneylog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL COMMENT '用户Id',
  `UserName` varchar(50) DEFAULT NULL COMMENT '用户名称',
  `TradeDate` datetime DEFAULT NULL COMMENT '交易日期',
  `TradeType` int(11) DEFAULT NULL COMMENT '交易类型 1.自助充值 2.后台加款 3.消费 4.提现 5.订单退款 6.推荐人提成',
  `Income` decimal(10,2) DEFAULT NULL COMMENT '转入金额',
  `Expenses` decimal(10,2) DEFAULT NULL COMMENT '转出金额',
  `Balance` decimal(10,2) DEFAULT NULL COMMENT '帐户余额',
  `Remark` text COMMENT '备注',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_userlevel`;
CREATE TABLE `eb_userlevel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `LevelName` varchar(50) DEFAULT NULL,
  `LevelId` int(11) DEFAULT NULL,
  `ImgPath` varchar(200) DEFAULT NULL,
  `MinCredit` int(11) DEFAULT NULL,
  `MaxCredit` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_useronline`;
CREATE TABLE `eb_useronline` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` char(40) DEFAULT NULL,
  `UserNiname` varchar(50) DEFAULT NULL,
  `UserGroupName` char(100) DEFAULT NULL,
  `AdminID` int(11) DEFAULT NULL,
  `Invisible` tinyint(4) DEFAULT NULL,
  `ActionInfo` longtext,
  `LastSearchTime` datetime DEFAULT NULL,
  `LastUpdateTime` datetime DEFAULT NULL,
  `WebUrl` longtext,
  `Verifycode` varchar(10) DEFAULT NULL,
  `Ip` char(15) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `UserOnline_UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=1708 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

DROP TABLE IF EXISTS `eb_payment`;
CREATE TABLE `eb_payment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `PaymentApi` varchar(255) DEFAULT NULL COMMENT '支付插件类型',
  `PaymentName` varchar(50) DEFAULT NULL COMMENT '支付方式名称',
  `UseMoney` decimal(10,0) DEFAULT NULL COMMENT '支付手续费(正数)，或免除费用（负数） ',
  `IsPercent` bit(1) DEFAULT NULL COMMENT '是否百分比',
  `IsUseInpour` bit(1) DEFAULT NULL COMMENT '是否用于预付款',
  `IsOpend` bit(1) DEFAULT NULL COMMENT '是否关闭',
  `OrderNumber` int(11) DEFAULT NULL COMMENT '显示顺序',
  `Demo` text COMMENT '备注',
  `ShowImg` varchar(250) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  `ShortName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_paylog`;
CREATE TABLE `eb_paylog` (
  `id` bigint(12) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `UserName` varchar(100) DEFAULT NULL,
  `Income` decimal(11,2) DEFAULT NULL,
  `Free` decimal(11,2) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  `TimeNumber` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
