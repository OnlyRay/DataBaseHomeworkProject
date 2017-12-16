# Host: 127.0.0.1  (Version 5.6.23-log)
# Date: 2017-10-16 22:12:18
# Generator: MySQL-Front 5.3  (Build 5.39)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "j"
#

DROP TABLE IF EXISTS `j`;
CREATE TABLE `j` (
  `jno` varchar(255) NOT NULL DEFAULT '',
  `jname` varchar(255) NOT NULL DEFAULT '',
  `city` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`jno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "j"
#

INSERT INTO `j` VALUES ('J1','三建','北京'),('J2','一汽','长春'),('J3','弹簧厂','天津'),('J4','造船厂','天津'),('J5','机车厂','唐山'),('J6','无线电厂','常州'),('J7','半导体厂','南京');

#
# Structure for table "p"
#

DROP TABLE IF EXISTS `p`;
CREATE TABLE `p` (
  `pno` varchar(255) NOT NULL DEFAULT '',
  `pname` varchar(255) NOT NULL DEFAULT '',
  `color` varchar(255) NOT NULL DEFAULT '',
  `weigth` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`pno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "p"
#

INSERT INTO `p` VALUES ('P1','螺母','红',12),('P2','螺栓','绿',17),('P3','螺丝刀','蓝',14),('P4','螺丝刀','红',14),('P5','凸轮','蓝',40),('P6','齿轮','红',30);

#
# Structure for table "s"
#

DROP TABLE IF EXISTS `s`;
CREATE TABLE `s` (
  `sno` varchar(255) NOT NULL DEFAULT '',
  `sname` varchar(255) NOT NULL DEFAULT '',
  `status` int(11) NOT NULL DEFAULT '0',
  `city` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`sno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "s"
#

INSERT INTO `s` VALUES ('S1','精益',20,'天津'),('S2','盛锡',10,'北京'),('S3','东方红',30,'北京'),('S4','丰泰盛',20,'天津'),('S5','为民',30,'上海');

#
# Structure for table "spj"
#

DROP TABLE IF EXISTS `spj`;
CREATE TABLE `spj` (
  `sno` varchar(255) NOT NULL DEFAULT '',
  `pno` varchar(255) NOT NULL DEFAULT '',
  `jno` varchar(255) NOT NULL DEFAULT '',
  `qty` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for table "spj"
#

INSERT INTO `spj` VALUES ('S1','P1','J1',200),('S1','P1','J3',100),('S1','P1','J4',700),('S1','P2','J2',100),('S2','P3','J1',400),('S2','P3','J2',200),('S2','P3','J4',500),('S2','P3','J5',400),('S2','P5','J1',400),('S2','P5','J2',100),('S3','P1','J1',200),('S3','P3','J1',200),('S4','P5','J1',100),('S4','P6','J3',300),('S4','P6','J4',200),('S5','P2','J4',100),('S5','P3','J1',200),('S5','P6','J2',200),('S5','P6','J4',500);
