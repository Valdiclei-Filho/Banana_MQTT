CREATE DATABASE  IF NOT EXISTS `banana` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `banana`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: banana
-- ------------------------------------------------------
-- Server version	8.2.0

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
-- Table structure for table `leitura_ambiente`
--

DROP TABLE IF EXISTS `leitura_ambiente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leitura_ambiente` (
  `ID` varchar(45) NOT NULL,
  `temperature` float DEFAULT NULL,
  `humidity` float DEFAULT NULL,
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leitura_ambiente`
--

LOCK TABLES `leitura_ambiente` WRITE;
/*!40000 ALTER TABLE `leitura_ambiente` DISABLE KEYS */;
INSERT INTO `leitura_ambiente` VALUES ('01a062f8-b9d3-411e-adab-acaf41dc1c02',25.3954,59.8892),('06a82900-8b04-4904-8d8d-7856da76ea59',25.2071,60.8045),('1562faec-dcbe-43b6-8dfe-316ffc2bc163',25.2674,60.3293),('177135c4-7025-4505-a0df-08236620cd71',25.3681,60.8959),('1856eff7-1a1c-4645-9af0-d837517caa13',25.4049,60.1585),('19ef8457-17a1-4329-9cbb-184696191627',25.4059,59.6768),('1a101258-6318-417b-8b4b-05c3785661e8',25.2218,60.9961),('2c562f18-790e-4c5a-98f1-fd53266a30d7',25.2861,60.1584),('3c4f0780-807e-4224-ba88-1fbdfd7c5709',25.3607,59.9098),('4fc73f90-90a2-4bfd-88ca-c7f7abbbf03a',25.4229,60.2413),('58ac802e-83a0-41f5-a490-6cc8a829b2d9',25.4538,60.2395),('64045918-3075-4792-9698-a98aa8647741',25.2018,60.8056),('65bb390c-c985-44d3-b874-ba2dde87de9e',25.1785,60.6415),('6ab10400-d35d-4599-be63-1b0cc77082ed',25.2386,60.6434),('6ab2c10c-7f63-401a-9d9c-0e63683a8c57',25.2533,60.643),('705c9c0d-c27c-4ea9-967d-6ef0073a55ea',25.3738,59.785),('7066a5b4-0903-415c-b8f8-4803895cfe53',25.2722,60.2839),('770c2310-e94f-43c8-91f6-7e767273f1a6',25.4307,59.7587),('84d486a0-9ee6-46b2-8280-5ffd67e950ec',25.4046,60.1821),('92897a23-c7e0-4dca-a72b-5ba95bebffbc',25.2661,60.38),('95f29a30-ab16-4f86-a93a-77f1c3106b43',25.3754,60.1126),('9b0b5ff6-6c8d-4f7f-b5d0-7f02ed3243f6',25.4124,59.9003),('a7440c5f-f483-4c16-95a9-4457888f6832',25.4118,60.2456),('a955f4b2-b682-4a5e-8916-de13dea78ddb',25.2409,60.1653),('ade3aac5-993c-4a55-aea3-9eff4f9752c6',25.4242,59.8101),('b22d765d-47a4-4ba9-b143-f1d74cc6f58e',25.4168,60.1807),('b9853f2a-d2e0-466c-b2ca-4b3b37001c73',25.417,60.0579),('c10ca693-5b96-4b54-87c4-ca26f0d979ac',25.4269,60.1385),('c313de4a-0c69-4885-a194-bcc74585095a',25.3738,60.1284),('d0af8a15-aca2-40e7-bb94-54cabc24892c',25.4251,60.282),('d6685c50-0a87-42c2-868e-df231abfcdaa',25.4082,60.7125),('e7787b89-4348-463e-958a-9807d57c6f9a',25.3983,59.9587),('e858b24d-b7e9-4241-9da5-3a8c799f4402',25.1701,60.5278),('fd726148-cf56-44a0-a34d-b66599f44d79',25.383,60.2495);
/*!40000 ALTER TABLE `leitura_ambiente` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-25 21:42:22
