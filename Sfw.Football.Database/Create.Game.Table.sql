CREATE TABLE IF NOT EXISTS `game` (
  `Id` int(11) NOT NULL,
  `Team1Id` int(11) NOT NULL,
  `Team2Id` int(11) NOT NULL,
  `WinningTeamId` int(11) NOT NULL,
  `Date` datetime,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `game`
(`Id`,
`Team1Id`,
`Team2Id`,
`WinningTeamId`,
`Date`)
VALUES
(1,1,2,2,"2015-08-19"),
(2,3,4,3,"2015-08-26"),
(3,5,6,5,"2015-09-02"),
(4,7,8,8,"2015-09-09")
ON DUPLICATE KEY UPDATE 
Team1Id = VALUES(Team1Id), 
Team2Id = VALUES(Team2Id), 
WinningTeamId = VALUES(WinningTeamId), 
Date = values(Date);
