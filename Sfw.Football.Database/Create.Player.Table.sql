CREATE TABLE IF NOT EXISTS `player` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Points` int(11) DEFAULT NULL,
  `GamesPlayed` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ratings correct as of 26-08-2015

INSERT INTO `player`
(`Id`,
`Name`,
`Points`,
`GamesPlayed`)
VALUES
(1,"Matt Smith",1,2),
(2,"Matt George",1,2),
(3,"David Raine",1,2),
(4,"James Beckenham",1,2),
(5,"Matt Overton",0,0),
(6,"Mike Murray",0,2),
(7,"Carlo Veo",1,2),
(8,"Rick Powell",1,1),
(9,"Richard Press",1,1),
(10,"Andrew von Gerard",0,1),
(11,"Joseph Freeston",0,2),
(12,"Nicky Simillie",1,1),
(13,"Dave Horsley",1,1),
(14,"Ben Turner",1,1),
(15,"Alan Gentle",0,0)
ON DUPLICATE KEY UPDATE
Name = VALUES(Name),
Points = VALUES(Points),
GamesPlayed = VALUES(GamesPlayed);