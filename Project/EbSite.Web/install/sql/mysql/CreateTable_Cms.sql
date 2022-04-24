
DROP TABLE IF EXISTS `eb_areainfo`;
CREATE TABLE `eb_areainfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `HeadID` int(11) DEFAULT NULL,
  `Level` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4378 DEFAULT CHARSET=utf8;




DROP TABLE IF EXISTS `eb_classconfigs`;
CREATE TABLE `eb_classconfigs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ContentHtmlName` varchar(100) DEFAULT NULL,
  `ClassHtmlNameRule` varchar(100) DEFAULT NULL,
  `IsCanAddContent` tinyint(4) DEFAULT NULL,
  `ContentModelID` char(36) DEFAULT NULL,
  `ContentTemID` char(36) DEFAULT NULL,
  `ClassTemID` char(36) DEFAULT NULL,
  `ClassModelID` char(36) DEFAULT NULL,
  `SubClassAddName` varchar(50) DEFAULT NULL,
  `SubClassTemID` char(36) DEFAULT NULL,
  `SubClassModelID` char(36) DEFAULT NULL,
  `SubDefaultContentModelID` char(36) DEFAULT NULL,
  `SubDefaultContentTemID` char(36) DEFAULT NULL,
  `SubIsCanAddSub` tinyint(2) DEFAULT NULL,
  `SubIsCanAddContent` tinyint(2) DEFAULT NULL,
  `IsCanAddSub` tinyint(2) DEFAULT NULL,
  `ListTemID` char(36) DEFAULT NULL,
  `PageSize` tinyint(3) DEFAULT NULL,
  `ModuleID` char(36) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `ClassTemIdMobile` char(36) DEFAULT NULL,
  `ContentTemIdMobile` char(36) DEFAULT NULL,
  `SiteID` int(11) DEFAULT NULL,
  `IsDefault` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `indexClassID` (`ClassID`),
  KEY `indexSiteID` (`SiteID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_friendlist`;
CREATE TABLE `eb_friendlist` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FriendName` varchar(40) DEFAULT NULL,
  `IsAllow` tinyint(4) DEFAULT NULL,
  `AddDate` datetime DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `UserNiName` varchar(20) DEFAULT NULL,
  `FriendID` int(11) DEFAULT NULL,
  `FriendNiName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `friendlist_UserID` (`UserID`),
  KEY `friendlist_FriendID` (`FriendID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_goods_visite`;
CREATE TABLE `eb_goods_visite` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `ContentID` int(11) DEFAULT NULL,
  `Count` int(11) DEFAULT NULL,
  `Ip` bigint(11) DEFAULT NULL,
  `NumTime` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ContentID` (`ContentID`) USING BTREE,
  KEY `UserID` (`UserID`) USING BTREE,
  KEY `NumTime` (`NumTime`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=326 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_invite`;
CREATE TABLE `eb_invite` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `InviteUserID` int(11) DEFAULT NULL,
  `InviteInviteNiName` varchar(50) DEFAULT NULL,
  `AddDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `invite_UserID` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_menus`;
CREATE TABLE `eb_menus` (
  `id` char(36) NOT NULL,
  `MenuName` varchar(80) DEFAULT NULL,
  `ImageUrl` varchar(225) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `ParentID` char(36) DEFAULT NULL,
  `Target` varchar(10) DEFAULT NULL,
  `CtrPath` varchar(200) DEFAULT NULL,
  `PageUrl` varchar(200) DEFAULT NULL,
  `IsLeftParent` varchar(10) DEFAULT NULL,
  `ModulesID` char(36) DEFAULT NULL,
  `Help` longtext,
  `AddTime` datetime DEFAULT NULL,
  `PermissionID` varchar(36) DEFAULT NULL,
  `SiteID` int(2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `menus_pid` (`ParentID`) USING BTREE,
  KEY `menus_SiteID` (`SiteID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_menusforuser`;
CREATE TABLE `eb_menusforuser` (
  `id` char(36) NOT NULL,
  `MenuName` varchar(80) DEFAULT NULL,
  `ImageUrl` varchar(225) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `ParentID` char(36) DEFAULT NULL,
  `Target` varchar(20) DEFAULT NULL,
  `ModuleMenuID` char(36) DEFAULT NULL,
  `PageUrl` longtext,
  `IsLeftParent` tinyint(4) DEFAULT NULL,
  `ModulesID` varchar(50) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `MenuType` tinyint(2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `menusforuser_ParentID` (`ParentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;



DROP TABLE IF EXISTS `eb_newsclass`;
CREATE TABLE `eb_newsclass` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(100) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `ParentID` int(11) DEFAULT NULL,
  `HtmlName` varchar(100) DEFAULT NULL,
  `Info` longtext,
  `TitleStyle` varchar(50) DEFAULT NULL,
  `SeoTitle` longtext,
  `dayHits` int(11) DEFAULT NULL,
  `weekHits` int(11) DEFAULT NULL,
  `monthhits` int(11) DEFAULT NULL,
  `lasthitstime` datetime DEFAULT NULL,
  `hits` int(11) DEFAULT NULL,
  `SeoKeyWord` varchar(100) DEFAULT NULL,
  `SeoDescription` varchar(300) DEFAULT NULL,
  `OutLike` varchar(100) DEFAULT NULL,
  `Annex1` varchar(100) DEFAULT NULL,
  `Annex2` varchar(200) DEFAULT NULL,
  `Annex3` varchar(300) DEFAULT NULL,
  `Annex4` varchar(400) DEFAULT NULL,
  `Annex5` varchar(500) DEFAULT NULL,
  `Annex6` varchar(600) DEFAULT NULL,
  `Annex7` varchar(700) DEFAULT NULL,
  `Annex8` varchar(800) DEFAULT NULL,
  `Annex9` int(11) DEFAULT NULL,
  `Annex10` int(11) DEFAULT NULL,
  `Annex11` int(11) NOT NULL DEFAULT '0',
  `Annex12` int(11) NOT NULL DEFAULT '0',
  `Annex13` int(11) NOT NULL DEFAULT '0',
  `Annex14` int(11) DEFAULT '0',
  `Annex15` float(11,2) unsigned NOT NULL DEFAULT '0.00',
  `CommentNum` int(11) DEFAULT NULL,
  `FavorableNum` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `IsUserTheme` tinyint(4) DEFAULT NULL,
  `IsAuditing` tinyint(4) DEFAULT NULL,
  `SiteID` tinyint(2) DEFAULT NULL,
  `RandNum` int(11) DEFAULT NULL,
  `NumberTime` int(11) DEFAULT NULL,
  `SubClassNum` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ClassParentID` (`ParentID`) USING BTREE,
  KEY `ClassSiteID` (`SiteID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=13023 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_newscontent`;
CREATE TABLE `eb_newscontent` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SmallPic` varchar(225) DEFAULT NULL,
  `NewsTitle` varchar(100) DEFAULT NULL,
  `TitleStyle` varchar(50) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  `hits` int(11) DEFAULT NULL,
  `IsGood` tinyint(4) DEFAULT NULL,
  `ContentInfo` longtext,
  `dayHits` int(11) DEFAULT NULL,
  `weekHits` int(11) DEFAULT NULL,
  `monthhits` int(11) DEFAULT NULL,
  `lasthitstime` datetime DEFAULT NULL,
  `TagIDs` varchar(200) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `HtmlName` varchar(200) DEFAULT NULL,
  `ContentHtmlNameRule` varchar(200) DEFAULT NULL,
  `MarkIsMakeHtml` tinyint(1) DEFAULT NULL,
  `IsComment` tinyint(1) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `IsAuditing` tinyint(1) DEFAULT NULL,
  `Annex1` varchar(100) DEFAULT NULL,
  `Annex2` varchar(200) DEFAULT NULL,
  `Annex3` varchar(300) DEFAULT NULL,
  `Annex4` varchar(400) DEFAULT NULL,
  `Annex5` varchar(500) DEFAULT NULL,
  `Annex6` varchar(600) DEFAULT NULL,
  `Annex7` varchar(700) DEFAULT NULL,
  `Annex8` varchar(800) DEFAULT NULL,
  `Annex9` varchar(900) DEFAULT NULL,
  `Annex10` longtext,
  `Annex11` int(11) NOT NULL DEFAULT '0',
  `Annex12` int(11) NOT NULL DEFAULT '0',
  `Annex13` int(11) NOT NULL DEFAULT '0',
  `Annex14` int(11) NOT NULL DEFAULT '0',
  `Annex15` int(11) NOT NULL DEFAULT '0',
  `Annex16` decimal(19,2) NOT NULL DEFAULT '0.00',
  `Annex17` decimal(19,2) NOT NULL DEFAULT '0.00',
  `Annex18` decimal(19,2) DEFAULT '0.00',
  `Annex19` float(11,2) NOT NULL DEFAULT '0.00',
  `Annex20` float(11,2) NOT NULL DEFAULT '0.00',
  `Annex21` int(11) NOT NULL DEFAULT '0',
  `Annex22` int(11) NOT NULL DEFAULT '0',
  `Annex23` int(11) NOT NULL DEFAULT '0',
  `Annex24` int(11) NOT NULL DEFAULT '0',
  `Annex25` int(11) NOT NULL DEFAULT '0',
  `ContentTemID` char(36) DEFAULT NULL,
  `Advs` int(11) DEFAULT NULL,
  `ClassName` varchar(100) DEFAULT NULL,
  `CommentNum` int(11) DEFAULT NULL,
  `FavorableNum` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `SiteID` tinyint(2) DEFAULT NULL,
  `RandNum` int(11) DEFAULT NULL,
  `NumberTime` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ContentUID` (`UserID`) USING BTREE,
  KEY `Content_ClassID` (`ClassID`) USING BTREE,
  KEY `ContentCID` (`ClassID`,`SiteID`,`IsAuditing`,`OrderID`) USING BTREE,
  KEY `Content_hits` (`hits`) USING BTREE,
  KEY `annex11` (`Annex11`),
  KEY `annex21` (`Annex21`) USING BTREE,
  KEY `classid` (`ClassID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=460 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_outlinks`;
CREATE TABLE `eb_outlinks` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `SiteName` varchar(50) DEFAULT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `LogoUrl` varchar(255) DEFAULT NULL,
  `QQ` varchar(20) DEFAULT NULL,
  `Email` char(40) DEFAULT NULL,
  `Tel` varchar(50) DEFAULT NULL,
  `Mobile` char(11) DEFAULT NULL,
  `Demo` varchar(300) DEFAULT NULL,
  `IsHaveLogo` tinyint(1) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `SiteID` int(11) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `IsAuditing` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `indexSiteIDIsHaveLogo` (`IsHaveLogo`,`SiteID`,`IsAuditing`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_recentvisitors`;
CREATE TABLE `eb_recentvisitors` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  `VisitorID` int(11) DEFAULT NULL,
  `VisitorName` varchar(40) DEFAULT NULL,
  `VisitorNiName` varchar(50) DEFAULT NULL,
  `LastDateTimeInt` int(12) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `recentvisitors_UserID` (`UserID`),
  KEY `recentvisitors_VisitorID` (`VisitorID`),
  KEY `recentvisitors_LastDateTimeInt` (`LastDateTimeInt`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_remark`;
CREATE TABLE `eb_remark` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Body` longtext,
  `Ip` char(15) DEFAULT NULL,
  `Quote` longtext,
  `Support` int(11) DEFAULT NULL,
  `Discourage` int(11) DEFAULT NULL,
  `Information` int(11) DEFAULT NULL,
  `DateAndTime` datetime DEFAULT NULL,
  `IsNiName` tinyint(4) DEFAULT NULL,
  `RemarkClassID` char(36) DEFAULT NULL,
  `IsAuditing` tinyint(4) DEFAULT NULL,
  `Mark` char(50) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserName` varchar(40) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  `EvaluationScore` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `remark_RemarkClassID` (`RemarkClassID`,`IsAuditing`,`Mark`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_remarksublist`;
CREATE TABLE `eb_remarksublist` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Body` longtext,
  `Ip` longtext,
  `Quote` longtext,
  `Support` int(11) DEFAULT NULL,
  `Discourage` int(11) DEFAULT NULL,
  `Information` int(11) DEFAULT NULL,
  `DateAndTime` datetime DEFAULT NULL,
  `IsNiName` tinyint(4) DEFAULT NULL,
  `IsAuditing` tinyint(4) DEFAULT NULL,
  `Mark` longtext,
  `UserID` int(11) DEFAULT NULL,
  `UserName` longtext,
  `UserNiName` longtext,
  `ParentID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_roles`;
CREATE TABLE `eb_roles` (
  `RoleID` int(11) NOT NULL AUTO_INCREMENT,
  `Role` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_searchword`;
CREATE TABLE `eb_searchword` (
  `id` varchar(50) NOT NULL DEFAULT '',
  `keyword` varchar(200) NOT NULL DEFAULT '',
  `searchcount` int(11) DEFAULT NULL,
  `addtime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`,`keyword`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_spacesetting`;
CREATE TABLE `eb_spacesetting` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `ReWriteName` varchar(100) DEFAULT NULL,
  `ThemeID` int(11) DEFAULT NULL,
  `ThemePath` varchar(100) DEFAULT NULL,
  `DefaultTabID` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `UpdatedateTime` datetime DEFAULT NULL,
  `VisitedTimes` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `spacesetting_UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_spacetabs`;
CREATE TABLE `eb_spacetabs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TabName` varchar(100) DEFAULT NULL,
  `Layout` varchar(200) DEFAULT NULL,
  `OrderNum` int(11) DEFAULT NULL,
  `ICOImg` varchar(200) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `ParentID` int(11) DEFAULT NULL,
  `Mark` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `spacetabs_UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_spacetabwidget`;
CREATE TABLE `eb_spacetabwidget` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TabID` int(11) DEFAULT NULL,
  `WidgetID` varchar(1000) DEFAULT NULL,
  `LayoutPane` varchar(50) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `OrderNum` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_spacethemeclass`;
CREATE TABLE `eb_spacethemeclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(50) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `UserGroupID` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_spacethemes`;
CREATE TABLE `eb_spacethemes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ThemeName` longtext,
  `ThemePath` varchar(50) DEFAULT NULL,
  `Author` varchar(10) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `AddTime` datetime DEFAULT NULL,
  `ThemeClassID` int(11) DEFAULT NULL,
  `UserGroupID` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=423 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_specialclass`;
CREATE TABLE `eb_specialclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `SpecialName` varchar(100) DEFAULT NULL,
  `Orderid` int(11) DEFAULT NULL,
  `Titletype` varchar(100) DEFAULT NULL,
  `Outlink` varchar(225) DEFAULT NULL,
  `HtmlName` varchar(200) DEFAULT NULL,
  `ClassHtmlNameRule` varchar(200) DEFAULT NULL,
  `SpecialTemID` char(36) DEFAULT NULL,
  `SeoTitle` varchar(200) DEFAULT NULL,
  `SeoKeyWord` varchar(300) DEFAULT NULL,
  `SeoDescription` varchar(300) DEFAULT NULL,
  `ParentID` int(11) DEFAULT NULL,
  `RelateClassIDs` varchar(1000) DEFAULT NULL,
  `SiteID` tinyint(2) DEFAULT NULL,
  `SpecialTemIDMobile` char(36) DEFAULT NULL,
  `SubClassNum` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `SpecialSiteID` (`SiteID`),
  KEY `SpecialParentID` (`ParentID`)
) ENGINE=InnoDB AUTO_INCREMENT=316 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_specialnews`;
CREATE TABLE `eb_specialnews` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `NewsID` int(11) DEFAULT NULL,
  `SpecialClassID` int(11) DEFAULT NULL,
  `orderid` int(11) DEFAULT NULL,
  `subclassid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `SpecialNewsClassID` (`SpecialClassID`),
  KEY `subclassid` (`subclassid`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_tagkey`;
CREATE TABLE `eb_tagkey` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TagName` varchar(100) DEFAULT NULL,
  `Num` int(11) DEFAULT NULL,
  `RelateClassIDs` varchar(1000) DEFAULT NULL,
  `SiteID` tinyint(2) DEFAULT NULL,
  `HtmlName` varchar(100) DEFAULT NULL,
  `HtmlNameRule` varchar(200) DEFAULT NULL,
  `SeoTitle` varchar(200) DEFAULT NULL,
  `SeoKeyWord` varchar(300) DEFAULT NULL,
  `SeoDescription` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_tagrelateclass`;
CREATE TABLE `eb_tagrelateclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TagID` int(11) DEFAULT NULL,
  `TagName` varchar(100) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `tagrelateclass_ClassID` (`ClassID`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_tagrelatenews`;
CREATE TABLE `eb_tagrelatenews` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TagID` int(11) DEFAULT NULL,
  `NewsID` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `tagrelatenews_TagID` (`TagID`) USING BTREE,
  KEY `tagrelatenews_NewsID` (`NewsID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_tagrelateuser`;
CREATE TABLE `eb_tagrelateuser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TagID` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserName` char(40) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `tagrelateuser_UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_tool_chatlist`;
CREATE TABLE `eb_tool_chatlist` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `SalerName` varchar(50) DEFAULT NULL COMMENT '销售名称',
  `SalerUserName` varchar(50) DEFAULT NULL,
  `SalerUserID` int(4) DEFAULT NULL,
  `UserID` int(4) DEFAULT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `UserNiName` varchar(50) DEFAULT NULL,
  `UserIP` varchar(20) DEFAULT NULL,
  `DateTime` datetime DEFAULT NULL,
  `Msg` text,
  `IsSalerSay` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=719 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_vote`;
CREATE TABLE `eb_vote` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `VoteName` varchar(50) DEFAULT NULL COMMENT '投票名称',
  `AllowMaxSel` int(4) DEFAULT NULL COMMENT '最多可以选择几个，只适用于多选情况',
  `IsMoreSel` tinyint(1) DEFAULT NULL COMMENT '是否多选择',
  `MarkInt` int(11) DEFAULT NULL COMMENT '整型标记,比字符串形快很多,如果标记是数字建议使用这个',
  `MarkStr` varchar(20) DEFAULT NULL COMMENT '字符串形唯一标记,如果是数字，建议使用markint,这个已经添加索引',
  `VoteCount` int(11) DEFAULT NULL COMMENT '投票总数目',
  `StartDate` int(10) DEFAULT NULL COMMENT '投票开始时间',
  `EndDate` int(10) DEFAULT NULL COMMENT '投票结束时间',
  `IsItemColorRan` tinyint(1) DEFAULT NULL COMMENT '查看投票时，是否随机显示选项的颜色',
  `VoteInfo` varchar(500) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IndexMarkInt` (`MarkInt`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_voteclass`;
CREATE TABLE `eb_voteclass` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(255) DEFAULT NULL,
  `AddUserID` int(11) DEFAULT NULL,
  `AddUserNiName` varchar(50) DEFAULT NULL,
  `AddDateTime` datetime DEFAULT NULL,
  `AddDateTimeInt` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_voteitem`;
CREATE TABLE `eb_voteitem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(50) DEFAULT NULL,
  `PostCount` int(11) DEFAULT NULL,
  `VoteID` int(10) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Index_Vote` (`VoteID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `eb_admin_roles`;
CREATE TABLE `eb_admin_roles` (
  `RoleID` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_admin_rolespermissions`;
CREATE TABLE `eb_admin_rolespermissions` (
  `RoleID` int(11) DEFAULT NULL,
  `PermissionID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_admin_user`;
CREATE TABLE `eb_admin_user` (
  `UserId` int(11) NOT NULL,
  `UserName` varchar(40) NOT NULL DEFAULT '',
  `isLock` tinyint(1) DEFAULT NULL,
  `LastLoginTime` datetime DEFAULT NULL,
  `CurrentSiteID` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserId`,`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_admin_userroles`;
CREATE TABLE `eb_admin_userroles` (
  `UserID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_admin_permissions`;
CREATE TABLE `eb_admin_permissions` (
  `PermissionID` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(300) DEFAULT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  PRIMARY KEY (`PermissionID`)
) ENGINE=InnoDB AUTO_INCREMENT=319 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_usergroupprofile`;
CREATE TABLE `eb_usergroupprofile` (
  `GroupID` int(11) NOT NULL AUTO_INCREMENT,
  `GroupName` char(100) DEFAULT NULL,
  `CreditShigher` int(11) DEFAULT NULL,
  `CreditSlower` int(11) DEFAULT NULL,
  `ShowColor` varchar(10) DEFAULT NULL,
  `IsSys` tinyint(4) DEFAULT NULL,
  `UserModelID` char(36) DEFAULT NULL,
  `AllowAddClass` longtext,
  `AllowAddContentNum` int(11) DEFAULT NULL,
  `IsAuditingMember` tinyint(4) DEFAULT NULL,
  `IsAllowDelete` tinyint(4) DEFAULT NULL,
  `IsAllowModify` tinyint(4) DEFAULT NULL,
  `IsAuditingContent` tinyint(4) DEFAULT NULL,
  `ManageIndex` varchar(225) DEFAULT NULL,
  `WebSiteIndex` varchar(225) DEFAULT NULL,
  PRIMARY KEY (`GroupID`),
  KEY `usergroupprofile_GroupID` (`GroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_usernews`;
CREATE TABLE `eb_usernews` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` char(40) DEFAULT NULL,
  `NewsInfo` longtext,
  `AddDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `usernews_UserName` (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_userprofile`;
CREATE TABLE `eb_userprofile` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` char(40) DEFAULT NULL,
  `QQ` varchar(40) DEFAULT NULL,
  `MSN` varchar(40) DEFAULT NULL,
  `ICO` varchar(40) DEFAULT NULL,
  `Sex` varchar(10) DEFAULT NULL,
  `BirthDay` datetime DEFAULT NULL,
  `Photo` varchar(225) DEFAULT NULL,
  `Bloodtype` varchar(20) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  `Province` varchar(20) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Postcode` char(6) DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  `Job` varchar(100) DEFAULT NULL,
  `Edu` varchar(100) DEFAULT NULL,
  `School` varchar(200) DEFAULT NULL,
  `Introduction` varchar(200) DEFAULT NULL,
  `UserModelID` char(36) DEFAULT NULL,
  `Annex1` varchar(100) DEFAULT NULL,
  `Annex2` varchar(200) DEFAULT NULL,
  `Annex3` varchar(300) DEFAULT NULL,
  `Annex4` varchar(400) DEFAULT NULL,
  `Annex5` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `userprofile_UserName` (`UserName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_userroles`;
CREATE TABLE `eb_userroles` (
  `UserRoleID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserRoleID`),
  KEY `userroles_UserID` (`UserID`),
  KEY `userroles_RoleID` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=226 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;


DROP TABLE IF EXISTS `eb_logs`;
CREATE TABLE `eb_logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(300) DEFAULT NULL,
  `Description` text,
  `LogType` tinyint(2) DEFAULT NULL,
  `AddDate` datetime DEFAULT NULL,
  `IP` char(15) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `log_index` (`LogType`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=155897 DEFAULT CHARSET=utf8;

