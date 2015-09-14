CREATE TABLE IF NOT EXISTS `team` (
  `Id` int(11) NOT NULL,
  `PlayerId` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`PlayerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- teams correct as of 28-08-15

INSERT INTO `team`
(`Id`,
`PlayerId`)
VALUES
(1,1),
(1,2),
(1,4),
(1,6),
(1,11),
(2,3),
(2,7),
(2,9),
(2,12),
(2,14),
(3,1),
(3,2),
(3,4),
(3,8),
(3,13),
(4,3),
(4,6),
(4,7),
(4,10),
(4,11),
(5,1),
(5,2),
(5,4),
(5,8),
(5,9),
(6,6),
(6,10),
(6,12),
(6,13),
(6,14),
(7,1),
(7,2),
(7,4),
(7,7),
(8,8),
(8,9),
(8,11),
(8,13),
(8,15)
ON DUPLICATE KEY UPDATE
PlayerId = VALUES(PlayerId);