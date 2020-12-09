-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3307
-- Generation Time: Dec 09, 2020 at 07:53 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotel_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `fname` varchar(50) NOT NULL,
  `sname` varchar(50) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `address` varchar(100) NOT NULL,
  `zip` varchar(15) NOT NULL,
  `country` varchar(25) NOT NULL,
  `gender` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `fname`, `sname`, `phone`, `address`, `zip`, `country`, `gender`) VALUES
(1, 'sdfdfg', 'sfgs', '265352234', 'dghdffas', '323', 'Finland', ''),
(2, 'ranar', 'klopp', '112', 'Keuda', '001', 'Iceland', ''),
(3, 'Kumbajaaaaaaa', 'sjkdfsdlgsd', 'sdjfsdlkfD', 'DFGJDK', 'DFGJD', 'FDGDFG', ''),
(7, 'ranar', 'klopp', '112', 'Keuda', '001', 'Estonia', ''),
(8, 'sdgfdfg', 'dfgdfgsds', '112', 'Keuda', '001', 'Estonia', ''),
(9, 'sdfsdg', 'dfgdf', 'sdf', '', '', '', ''),
(11, 'sdfsdg', 'dfgdf', 'sdf', '', '', '', ''),
(12, 'sdfsdg', 'dfgdf', 'sdf', '', '', '', ''),
(13, 'sdfsdg', 'dfgdf', 'sdf', '', '', '', ''),
(14, 'ranar', 'klopp', '112', 'Keuda', '001', 'sdg', ''),
(15, 'Ranar', 'Ranar', 'Ranar', 'Ranar', 'Ranar', 'Ranar', 'F'),
(16, 'Merk', 'Merk', 'Merk', 'Merk', 'Merk', 'Merk', 'M'),
(17, 'Nipi', 'Tiri', 'Tiri', 'Nippi', '111', '222', 'Female'),
(18, 'Ranar', 'Klopp', '+358', 'Leiko', '00110', 'Estonia', 'Male');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin'),
(2, 'USERNAME', 'PASSWORD'),
(3, 'U S E R N A M E', 'P A S S W O R D');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
