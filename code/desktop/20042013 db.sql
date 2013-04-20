-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: shoppingdb
-- ------------------------------------------------------
-- Server version	5.5.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `shoppingdb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `shoppingdb` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `shoppingdb`;

--
-- Table structure for table `contactus`
--

DROP TABLE IF EXISTS `contactus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contactus` (
  `id` varchar(100) NOT NULL,
  `feedDate` datetime DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `address` varchar(245) DEFAULT NULL,
  `mobileno` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `feedback` varchar(545) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactus`
--

LOCK TABLES `contactus` WRITE;
/*!40000 ALTER TABLE `contactus` DISABLE KEYS */;
INSERT INTO `contactus` VALUES ('41373.8325975347','2013-04-09 00:00:00','as','a','s','sa','Customer','sa'),('41373.8433135417','2013-04-09 00:00:00','d bd','gdf','df','bfd','bfdb ','fdfb'),('41373.8536373958','2013-04-09 00:00:00','1qwe','qwe','wqew','qe','Customer','qwe'),('41384.7868687731','2013-04-20 00:00:00','bv v',' vb',' nv',' nv',' nv v','n ');
/*!40000 ALTER TABLE `contactus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedback`
--

DROP TABLE IF EXISTS `feedback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feedback` (
  `id` varchar(100) NOT NULL,
  `item` varchar(100) DEFAULT NULL,
  `feedDate` datetime DEFAULT NULL,
  `name` varchar(145) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `feedback` varchar(545) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback`
--

LOCK TABLES `feedback` WRITE;
/*!40000 ALTER TABLE `feedback` DISABLE KEYS */;
INSERT INTO `feedback` VALUES ('41384.8213537963','aboutTheProductLbl','2013-04-20 00:00:00','mfh','hmfhm','hfm','hfmhf'),('41384.8254363542','NOKIA LUMIA 520','2013-04-20 00:00:00','ghkg','hkghkgh','khgk','kghk'),('41384.8256780093','NOKIA LUMIA 520','2013-04-20 00:00:00','ghkgvhmhg','hkghkgh','khgk','kghk'),('41384.8303572569','Mobile Store','2013-04-20 00:00:00','fngfng','fmnmf','hfmhm','fhmhf'),('41384.8304485185','Mobile Store','2013-04-20 00:00:00','name','fmnmf','hfmhm','fhmhf'),('41384.8468093519','NOKIA LUMIA 520','2013-04-20 00:00:00',' vc',' c',' cv','c '),('41384.8470637847','Mobile Store','2013-04-20 00:00:00','bv','vb xcb','xb','vbvx'),('41384.8645261806','Shop Name','2013-04-20 00:00:00','dngdg','ngn','gn','dgngd'),('41384.8646090394','Product Name','2013-04-20 00:00:00','dgngd','ngn','dgnd','gdg');
/*!40000 ALTER TABLE `feedback` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `brand` varchar(100) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `image` longblob,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('41375.7588948958','NOKIA LUMIA 520','NOKIA','Electronics','Powered by Windows Phone 8, the Nokia Lumia 520 comes with exclusive digital lenses, a 1GHz dual core processor, and a touchscreen that even works with long finger nails or gloves.',NULL),('41375.7669710764','NOKIA LUMIA 920','NOKIA','Electronics','Colourful unibody design with Carl Zeiss lens, PureView technology with Optical Image Stabilisation, and a 4.5’’ PureMotion HD+ display.',NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shop`
--

DROP TABLE IF EXISTS `shop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shop` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `tag` varchar(100) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `rating` varchar(45) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shop`
--

LOCK TABLES `shop` WRITE;
/*!40000 ALTER TABLE `shop` DISABLE KEYS */;
INSERT INTO `shop` VALUES ('41375.7766051389','Mobile Store','mobile for all','Electronics','4','The MobileStore Limited, India\'s first countrywide chain of telecom retail outlets and largestmobile phone retailer.');
/*!40000 ALTER TABLE `shop` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-04-20 20:46:39
