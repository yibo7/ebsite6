
INSERT INTO `eb_users` VALUES ('1', '#UserName#', '#UserPass#', '#UserEmail#', '1', '0', '2010-04-25 00:00:00', '2013-12-20 10:46:59', '2010-04-25 00:00:00', '2010-04-25 00:00:00', '0', '2010-04-25 00:00:00', '19666', 'eBSite', '', '15811071089', '6', null, null);

INSERT INTO `eb_errinfo` VALUES ('2', '发生404错误', '您访问的页面不存在,或者被迁移!', '0', '1');
INSERT INTO `eb_errinfo` VALUES ('3', '发生系统异常', '抱歉，您访问的页面发生系统错误，已经向管理员报告，请稍后再访问！', '0', '1');
INSERT INTO `eb_errinfo` VALUES ('4', '帐号等待管理员激活', '&lt;span style=&quot;font-size:24px;color:#FF0000;&quot;&gt;您好，您的注册已经成功,正在等待管理员审核通过...&lt;/span&gt;&lt;br /&gt;', '0', '1');
INSERT INTO `eb_errinfo` VALUES ('5', '帐号需要通过Email激活', '&lt;span style=&quot;font-size:24px;color:#FF0000;&quot;&gt;您好，您已经注册成功，现在请登录到您注册的email，点击连接来激活帐号！&lt;/span&gt;&lt;br /&gt;', '0', '1');
INSERT INTO `eb_errinfo` VALUES ('6', '您访问的模块不存在', '&nbsp;您访问的模块可能没有安装，请先安装模块，或菜单文件发生变化，请重新生成。', '7', '1');
INSERT INTO `eb_errinfo` VALUES ('7', '操作出错', '系统无法处理您所提交的数据，请再次确认数据的正确性', '0', '1');
INSERT INTO `eb_errinfo` VALUES ('8', '第三方登录插件未安装', '登录错误，可能第三方登录插件未安装,请在后台管理-模块与插件-插件管理确认是否已经安装！', '6', '1');




INSERT INTO `eb_payment` VALUES ('8', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '支付宝', '0', '', '', '', '0', '在线支付-支付平台', '/uploadfile/paymenticos/lhfsx2jeepl.gif', '2', 'Alipay');
INSERT INTO `eb_payment` VALUES ('9', 'EbSite.Plugin.Payment.Tenpay.Payment', '财付通', '0', '', '', '', '0', '在线支付-支付平台', '/uploadfile/paymenticos/u5s14suppzt.gif', '2', 'Tenpay');
INSERT INTO `eb_payment` VALUES ('11', 'EbSite.Plugin.Payment.AlipayBankPay_BOCB2C.Payment', '中国银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/oe2awiou1qm.gif', '3', 'boc');
INSERT INTO `eb_payment` VALUES ('12', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '招商银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/igoyb0hrqga.gif', '4', 'cmb');
INSERT INTO `eb_payment` VALUES ('13', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国工商银行', '0', '', '', '', '0', '储蓄卡快捷支付', '/uploadfile/paymenticos/fxv2s0bktza.gif', '5', 'icbc');
INSERT INTO `eb_payment` VALUES ('14', 'EbSite.Plugin.Payment.AlipayBankPay_ICBCB2C.Payment', '中国工商银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/zr04bdjntxm.gif', '3', 'icbc');
INSERT INTO `eb_payment` VALUES ('15', 'EbSite.Plugin.Payment.AlipayBankPay_CCB.Payment', '中国建设银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/nzh3eunafyt.gif', '3', 'ccb');
INSERT INTO `eb_payment` VALUES ('16', 'EbSite.Plugin.Payment.AlipayBankPay_COMM.Payment', '交通银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/yuuekzd4gmi.gif', '3', 'comm');
INSERT INTO `eb_payment` VALUES ('17', 'EbSite.Plugin.Payment.AlipayBankPay_ABC.Payment', '中国农业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/w3qvhj04lgc.gif', '3', 'abc');
INSERT INTO `eb_payment` VALUES ('18', 'EbSite.Plugin.Payment.AlipayBankPay_SPDB.Payment', '浦发银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/q4xgbi1ceqq.gif', '3', 'spdb');
INSERT INTO `eb_payment` VALUES ('19', 'EbSite.Plugin.Payment.AlipayBankPay_CIB.Payment', '兴业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/pc3pgfocvr2.gif', '3', 'ib');
INSERT INTO `eb_payment` VALUES ('20', 'EbSite.Plugin.Payment.AlipayBankPay_CEBBANK.Payment', '中国光大银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/ih1ukvxpogy.gif', '3', 'ceb');
INSERT INTO `eb_payment` VALUES ('21', 'EbSite.Plugin.Payment.AlipayBankPay_CMB.Payment', '招商银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/hkwcloa00dq.gif', '3', 'cmb');
INSERT INTO `eb_payment` VALUES ('22', 'EbSite.Plugin.Payment.AlipayBankPay_GDB.Payment', '广东发展银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/mimgeud4qzr.gif', '3', 'gdb');
INSERT INTO `eb_payment` VALUES ('23', 'EbSite.Plugin.Payment.AlipayBankPay_CMBC.Payment', '中国民生银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/b5bfypjj3vp.gif', '3', 'msb');
INSERT INTO `eb_payment` VALUES ('24', 'EbSite.Plugin.Payment.AlipayBankPay_SDB.Payment', '深圳发展银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/3samg4tiwnr.gif', '3', 'sdb');
INSERT INTO `eb_payment` VALUES ('25', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国建设银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/qciyyl2u1v2.gif', '4', 'ccb');
INSERT INTO `eb_payment` VALUES ('26', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国工商银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/sewvzr0bxvm.gif', '4', 'icbc');
INSERT INTO `eb_payment` VALUES ('27', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/1squja5lyyr.gif', '4', 'boc');
INSERT INTO `eb_payment` VALUES ('28', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '深圳发展银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/kn2p2gtbnes.gif', '4', 'sdb');
INSERT INTO `eb_payment` VALUES ('29', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国农业银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/5z1teqag5m3.gif', '4', 'abc');
INSERT INTO `eb_payment` VALUES ('30', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国光大银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/seurmccaqvd.gif', '4', 'ceb');
INSERT INTO `eb_payment` VALUES ('31', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '平安银行', '0', '', '', '', '0', '信用卡快捷支付', '/uploadfile/paymenticos/jeu5m3s1jon.png', '4', 'untitled');
INSERT INTO `eb_payment` VALUES ('32', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国建设银行', '0', '', '', '', '0', '储蓄卡快捷支付', '/uploadfile/paymenticos/0otsw1j4rvp.gif', '5', 'ccb');
INSERT INTO `eb_payment` VALUES ('33', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国农业银行', '0', '', '', '', '0', '储蓄卡快捷支付', '/uploadfile/paymenticos/ktsw5n4vrhh.gif', '5', 'abc');
INSERT INTO `eb_payment` VALUES ('34', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国银行', '0', '', '', '', '0', '储蓄卡快捷支付', '/uploadfile/paymenticos/k40ntdci0jp.gif', '5', 'boc');
INSERT INTO `eb_payment` VALUES ('35', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '深圳发展银行', '0', '', '', '', '0', '储蓄卡快捷支付', '/uploadfile/paymenticos/bhhstepkhsv.gif', '5', 'sdb');
INSERT INTO `eb_payment` VALUES ('36', 'EbSite.Plugin.Payment.Alipay_Instant.Payment', '中国光大银行', '0', '', '', '', '0', '储蓄卡快捷支付', '/uploadfile/paymenticos/cqul3x4q5oq.gif', '5', 'ceb');
INSERT INTO `eb_payment` VALUES ('37', 'EbSite.Plugin.Payment.AlipayBankPay_BJBANK.Payment', '北京银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/520tbsx5xvd.png', '3', 'b');
INSERT INTO `eb_payment` VALUES ('38', 'EbSite.Plugin.Payment.AlipayBankPay_BJRCB.Payment', '北京农村商业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/tbf0qiq3oda.png', '3', 'b');
INSERT INTO `eb_payment` VALUES ('39', 'EbSite.Plugin.Payment.AlipayBankPay_CITIC.Payment', '中信银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/bj2azdfjw5i.png', '3', 'b');
INSERT INTO `eb_payment` VALUES ('40', 'EbSite.Plugin.Payment.AlipayBankPay_FDB.Payment', '富滇银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/xn13pipoiaw.png', '3', 'b');
INSERT INTO `eb_payment` VALUES ('41', 'EbSite.Plugin.Payment.AlipayBankPay_HZCBB2C.Payment', '杭州银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/5iznatux1cn.png', '4', 'b');
INSERT INTO `eb_payment` VALUES ('42', 'EbSite.Plugin.Payment.AlipayBankPay_NBBANK.Payment', '宁波银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/s1kulg4j3m2.png', '3', 'b');
INSERT INTO `eb_payment` VALUES ('43', 'EbSite.Plugin.Payment.AlipayBankPay_PSBCDEBIT.Payment', '中国邮政储蓄银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/anc0cqilvma.png', '3', 'd');
INSERT INTO `eb_payment` VALUES ('44', 'EbSite.Plugin.Payment.AlipayBankPay_SHBANK.Payment', '上海银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/avqvk5lps3s.png', '3', 'b');
INSERT INTO `eb_payment` VALUES ('45', 'EbSite.Plugin.Payment.AlipayBankPay_SPABANK.Payment', '平安银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/5uyhcl4ejrr.png', '3', 'd');
INSERT INTO `eb_payment` VALUES ('46', 'EbSite.Plugin.Payment.AlipayBankPay_WZCBB2CDEBIT.Payment', '温州银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/fglyekvrjis.png', '5', 'w');
INSERT INTO `eb_payment` VALUES ('47', 'EbSite.Plugin.Payment.AlipayBankPay_ABCBTB.Payment', '中国农业企业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/rkyqqgqc52o.png', '3', 'n');
INSERT INTO `eb_payment` VALUES ('48', 'EbSite.Plugin.Payment.AlipayBankPay_CCBBTB.Payment', '中国建设企业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/vpxox2drjp2.png', '3', 'j');
INSERT INTO `eb_payment` VALUES ('49', 'EbSite.Plugin.Payment.AlipayBankPay_ICBCBTB.Payment', '中国工商企业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/uyf2y2fyjo2.png', '3', 'g');
INSERT INTO `eb_payment` VALUES ('50', 'EbSite.Plugin.Payment.AlipayBankPay_SPDBB2B.Payment', '浦发企业银行', '0', '', '', '', '0', '在线支付-网银支付', '/uploadfile/paymenticos/q5y13zni2iv.png', '3', 'p');



INSERT INTO `eb_paytypeinfo` VALUES ('1', '0', '在线支付', '在线支付', '1');
INSERT INTO `eb_paytypeinfo` VALUES ('2', '0', '支付平台', '第三方支付平台，如要有平台帐号才能支付', '2');
INSERT INTO `eb_paytypeinfo` VALUES ('3', '0', '网上银行', '需要开通网上银行才可以支付,使用之前确保您已经开通网银功能', '3');
INSERT INTO `eb_paytypeinfo` VALUES ('4', '0', '信用卡快捷支付', '无需开通网银，有信用卡就能网上支付', '4');
INSERT INTO `eb_paytypeinfo` VALUES ('5', '0', '储蓄卡支付', '无需开通网银，有储蓄卡就能网上支付', '5');



INSERT INTO `eb_shippers` VALUES ('1', '0', '五方天雅', '刘小波', '8', '北京五方天雅汽配城西A22-201', '13521633037', '010-88889658', '100000', '系统 测试', '北迈汽配');



INSERT INTO `eb_userlevel` VALUES ('1', '新手', '1', '', '1', '80');
INSERT INTO `eb_userlevel` VALUES ('2', '小学生', '2', '', '81', '400');
INSERT INTO `eb_userlevel` VALUES ('3', '初中生', '8', '', '401', '1000');
INSERT INTO `eb_userlevel` VALUES ('4', '高中生', '11', '', '1001', '5000');
INSERT INTO `eb_userlevel` VALUES ('5', '大学生', '14', '', '5001', '15000');
INSERT INTO `eb_userlevel` VALUES ('6', '硕士生', '18', '', '15001', '20000');
INSERT INTO `eb_userlevel` VALUES ('7', '博士', '21', '', '20001', '0');




INSERT INTO `eb_orderoptionitems` VALUES ('1', '7', 'dfd', '', null, '30', '0', null);
INSERT INTO `eb_orderoptionitems` VALUES ('2', '7', '8i8i', '', 'yg', '56', '1', null);
INSERT INTO `eb_orderoptionitems` VALUES ('3', '8', 'erer', '', null, '45', '0', null);
INSERT INTO `eb_orderoptionitems` VALUES ('4', '10', '普通发票', '', null, '4', '1', '');
INSERT INTO `eb_orderoptionitems` VALUES ('5', '10', '增值税发票', '', '发票抬头', '17', '1', '');
INSERT INTO `eb_orderoptionitems` VALUES ('6', '10', '个人发票', '', null, '30', '0', '大');
INSERT INTO `eb_orderoptionitems` VALUES ('7', '11', '普通木箱', '', null, '5', '0', '一般普通木箱,适用于普通商品');
INSERT INTO `eb_orderoptionitems` VALUES ('8', '11', '高级木箱', '', null, '20', '0', '适用于易碎商品');
INSERT INTO `eb_orderoptionitems` VALUES ('9', '11', 'VIP包装', '', '包装名称', '1', '1', 'VIP包装是本站VIP会员独享包装，包装精致完美实用，推荐使用。');
INSERT INTO `eb_orderoptionitems` VALUES ('11', '10', 'fas', '', null, '20', '1', 'fsd');
INSERT INTO `eb_orderoptionitems` VALUES ('12', '10', 'fa', '', null, '200', '0', '');




INSERT INTO `eb_orderoptions` VALUES ('10', '开具发票', '0', '如果您需要开发票请在这里选择，本站提供三种发票');
INSERT INTO `eb_orderoptions` VALUES ('11', '特殊包装', '1', '如果您需要特殊包装请在这里选择，不同的包装费用不一样');



