USE sfwfootballdev;

CREATE TABLE IF NOT EXISTS `player` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ratings correct as of 19-08-2015

INSERT INTO `player`
(`Id`,
`Name`,
`Rating`)
VALUES
(1,"Matt Smith",-1),
(2,"Matt George",-1),
(3,"David Raine",1),
(4,"James Beckenham",-1),
(5,"Matt Overton",0),
(6,"Mike Murray",-1),
(7,"Carlo Veo",1),
(8,"Rick Powell",0),
(9,"Richard Press",1),
(10,"Andrew von Gerard",0),
(11,"Joseph Freeston",-1),
(12,"Nicky Simillie",1),
(13,"Dave Horsley",0),
(14,"Ben Turner",1),
(15,"Alan Gentle",0);
