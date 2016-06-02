CREATE TABLE `db_version` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`from_version` INT(11) NOT NULL,
	`current_version` INT(11) NOT NULL,
	`last_update_datetime` DATETIME NOT NULL,
	PRIMARY KEY (`id`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

CREATE TABLE `log` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`appid` INT(11) NULL DEFAULT NULL COMMENT '应用Id',
	`appname` VARCHAR(50) NULL DEFAULT NULL COMMENT '应用名称',
	`message` VARCHAR(50) NULL DEFAULT NULL COMMENT '日志信息',
	`createdate` DATETIME NULL DEFAULT NULL COMMENT '创建时间',
	`tag` VARCHAR(50) NULL DEFAULT NULL COMMENT '标记',
	`loglevel` TINYINT(10) NULL DEFAULT NULL COMMENT '日志级别',
	`ip` VARCHAR(50) NULL DEFAULT NULL COMMENT 'IP信息',
	INDEX `id` (`id`)
)
COMMENT='日志'
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
CREATE TABLE `log_app` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`name` VARCHAR(50) NULL DEFAULT NULL COMMENT '应用名称',
	`description` VARCHAR(50) NULL DEFAULT NULL COMMENT '描述',
	`userid` INT(11) NULL DEFAULT NULL COMMENT '所属用户ID',
	`isrecord` TINYINT(4) NULL DEFAULT NULL COMMENT '是否记录',
	`createdate` DATETIME NULL DEFAULT NULL COMMENT '创建时间',
	INDEX `id` (`id`)
)
COMMENT='应用服务'
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;


CREATE TABLE `log_relation` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`userid` INT(11) NULL DEFAULT NULL COMMENT '用户ID',
	`inviteuserid` INT(11) NULL DEFAULT NULL COMMENT '邀请人ID',
	`appid` INT(11) NULL DEFAULT NULL COMMENT '应用服务ID',
	`isaccept` TINYINT(4) NULL DEFAULT NULL COMMENT '是否接受',
	`createdate` DATETIME NULL DEFAULT NULL COMMENT '创建时间',
	INDEX `id` (`id`)
)
COMMENT='用户关系'
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

CREATE TABLE `log_user` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`username` VARCHAR(50) NOT NULL COMMENT '用户名称',
	`realname` VARCHAR(50) NOT NULL COMMENT '真实姓名',
	`password` VARCHAR(50) NOT NULL COMMENT '密码',
	`createdate` DATETIME NOT NULL COMMENT '创建时间',
	INDEX `id` (`id`)
)
COMMENT='用户信息'
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;



