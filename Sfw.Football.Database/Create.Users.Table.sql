CREATE TABLE IF NOT EXISTS `users` (
	`Id` varchar(128) NOT NULL,
	`Email` varchar(256) DEFAULT NULL,
	`PasswordHash` longtext,
	`UserName` varchar(256) NOT NULL,
	PRIMARY KEY(`Id`)
);