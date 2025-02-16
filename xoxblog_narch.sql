-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Feb 16, 2025 at 01:46 PM
-- Server version: 10.4.34-MariaDB
-- PHP Version: 7.2.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `xoxblog_narch`
--

-- --------------------------------------------------------

--
-- Table structure for table `Categories`
--

CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Order` int(11) NOT NULL,
  `Status` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Dumping data for table `Categories`
--

INSERT INTO `Categories` (`Id`, `Name`, `Order`, `Status`) VALUES
(1, 'Yapay Zeka', 1, 1),
(2, 'Csharp', 2, 1),
(3, 'Entity Framework', 3, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Posts`
--

CREATE TABLE `Posts` (
  `Id` int(11) NOT NULL,
  `OwnerId` int(11) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Title` varchar(500) NOT NULL,
  `Text` text NOT NULL,
  `Keywords` varchar(1000) NOT NULL,
  `BannerImage` varchar(250) NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  `Order` int(11) NOT NULL,
  `Status` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Dumping data for table `Posts`
--

INSERT INTO `Posts` (`Id`, `OwnerId`, `CategoryId`, `Title`, `Text`, `Keywords`, `BannerImage`, `CreatedAt`, `UpdatedAt`, `Order`, `Status`) VALUES
(1, 1, 2, 'Neden Csharp?', 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 'csharp, c#, mono, monolitik,monolithic', 'https://dummyimage.com/700x350/dee2e6/6c757d.jpg', '2025-02-03 21:16:39', '2025-02-03 21:16:39', 1, 1),
(2, 1, 3, 'Neden Csharp? 2', 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 'csharp, c#, mono, monolitik,monolithic', 'https://dummyimage.com/700x350/dee2e6/6c757d.jpg', '2025-02-03 21:16:39', '2025-02-03 21:16:39', 1, 1),
(3, 1, 2, 'Neden Csharp? 3', 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 'csharp, c#, mono, monolitik,monolithic', 'https://dummyimage.com/700x350/dee2e6/6c757d.jpg', '2025-02-03 21:16:39', '2025-02-03 21:16:39', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE `Users` (
  `Id` int(11) NOT NULL,
  `NameSurname` varchar(200) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Dumping data for table `Users`
--

INSERT INTO `Users` (`Id`, `NameSurname`, `Username`, `Password`) VALUES
(1, 'Yasin Karaman', 'admin', 'e10adc3949ba59abbe56e057f20f883e');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Categories`
--
ALTER TABLE `Categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Posts`
--
ALTER TABLE `Posts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `OwnerId` (`OwnerId`),
  ADD KEY `CategoryId` (`CategoryId`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Categories`
--
ALTER TABLE `Categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `Posts`
--
ALTER TABLE `Posts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Posts`
--
ALTER TABLE `Posts`
  ADD CONSTRAINT `Posts_ibfk_1` FOREIGN KEY (`OwnerId`) REFERENCES `Users` (`Id`),
  ADD CONSTRAINT `Posts_ibfk_2` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
