-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: db_technoservice
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `application`
--

DROP TABLE IF EXISTS `application`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `application` (
  `idapplication` int NOT NULL,
  `date_addition` date DEFAULT NULL,
  `equipment` int DEFAULT NULL,
  `equipment_number` varchar(30) DEFAULT NULL,
  `equipment_name` varchar(45) DEFAULT NULL,
  `type_fault` int DEFAULT NULL,
  `description_problem` text,
  `client` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `executor` int DEFAULT NULL,
  `comment` text,
  `execution_time` time DEFAULT NULL,
  `date_completion` date DEFAULT NULL,
  `cost` int DEFAULT NULL,
  PRIMARY KEY (`idapplication`),
  KEY `fk_equipment_idx` (`equipment`),
  KEY `fk_fault_idx` (`type_fault`),
  KEY `fk_executor_idx` (`executor`),
  CONSTRAINT `fk_equipment` FOREIGN KEY (`equipment`) REFERENCES `equipment` (`idequipment`),
  CONSTRAINT `fk_executor` FOREIGN KEY (`executor`) REFERENCES `user` (`iduser`),
  CONSTRAINT `fk_fault` FOREIGN KEY (`type_fault`) REFERENCES `type_fault` (`idtype_fault`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES (1,'2024-02-15',1,'32142324','Asus ноутбук',1,'Не видит оперативную память','Кузнецов Всеволод Гиргорьевич','Выполнено',11,'Куплена матрица клавиатуры. Причина: износ и не бережное обращение','10:00:00','2024-02-17',5200),(2,'2024-02-14',2,'32142323','Samsung холодильник',2,'Не показывает картинку\r\n\r\n\r\n','Романов Петр Николаевич','Выполнено',11,'Куплена ручка холодильника, крепление ручки. Причина: износ\r\n\r\n\r\n','10:00:00','2024-04-17',1200),(3,'2024-02-13',3,'98862643','Apple телефон',1,'Мигает экран','Васнецов Николай Викторович','Выполнено',4,'Куплено матрица камеры, стекло камеры, клей. Причина: сильный удар.','02:00:00','2024-02-13',1000),(4,'2024-02-14',4,'97641726','J200 утюг',2,'Не печатает','Добронравов Виктор Максимович','Выполнено',3,NULL,'05:00:00','2024-02-15',1500),(5,'2024-03-16',1,'97626483','h',1,'Все плохо\r\n\r\n\r\n\r\n','h','Выполнено',3,'Куплена ручка холодильника, крепление ручки. Причина: износ\r\n\r\n','12:00:00','2024-03-17',5678);
/*!40000 ALTER TABLE `application` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-01 17:15:47
