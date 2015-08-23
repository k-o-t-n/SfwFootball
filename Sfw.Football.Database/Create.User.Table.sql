CREATE TABLE IF NOT EXISTS `user` (
	`Id` varchar(128) NOT NULL,
	`Email` varchar(256) DEFAULT NULL,
	`PasswordHash` longtext,
	`UserName` varchar(256) NOT NULL,
	PRIMARY KEY(`Id`)
);

DELETE FROM `user`;

INSERT INTO `user`
(`Id`,
`Email`,
`PasswordHash`,
`UserName`)
VALUES
("SfwFootballUsers/matts", null, "AIhU5XSwBzj+E22wSEKW/M7ySagEBLBXrCEONNPj7RaljA8NNlpBC7hB//EvtMH1wQ==", "matts")