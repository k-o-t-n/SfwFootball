USE sfwfootballdev;

CREATE TABLE IF NOT EXISTS `player` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

INSERT INTO `sfwfootballdev`.`player`
(`Id`,
`Name`,
`Rating`)
VALUES
(1,"Matt Smith",0),
(2,"Matt George",0),
(3,"David Raine",0),
(4,"James Beckenham",0),
(5,"Matt Overton",0),
(6,"Mike Murray",0),
(7,"Carlo Veo",0),
(8,"Rick Powell",0),
(9,"Richard Press",0),
(10,"Andrew Von Gerard",0),
(11,"Joseph Freeston?",0);