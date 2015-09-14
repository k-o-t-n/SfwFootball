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
(1,"Matt Smith",2,4),
(2,"Matt George",2,4),
(3,"David Raine",1,2),
(4,"James Beckenham",2,4),
(5,"Matt Overton",0,0),
(6,"Mike Murray",0,3),
(7,"Carlo Veo",1,3),
(8,"Rick Powell",3,3),
(9,"Richard Press",3,3),
(10,"Andrew von Gerard",0,2),
(11,"Joseph Freeston",0,3),
(12,"Nicky Simillie",1,2),
(13,"Dave Horsley",2,3),
(14,"Ben Turner",1,2),
(15,"Alan Gentle",1,1)
ON DUPLICATE KEY UPDATE
Name = VALUES(Name),
Points = VALUES(Points),
GamesPlayed = VALUES(GamesPlayed);