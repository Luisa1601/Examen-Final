-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 06, 2021 at 05:32 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bd_vacunas`
--

-- --------------------------------------------------------

--
-- Table structure for table `consultas`
--

CREATE TABLE `consultas` (
  `id` int(11) NOT NULL,
  `usuario` varchar(45) DEFAULT NULL,
  `tipo_consulta` varchar(45) DEFAULT NULL,
  `fecha_hora` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `consultas`
--

INSERT INTO `consultas` (`id`, `usuario`, `tipo_consulta`, `fecha_hora`) VALUES
(1, 'Salva', 'vacunas', '0000-00-00 00:00:00'),
(2, 'Salva', 'DPI 3441418292205', '0000-00-00 00:00:00'),
(3, 'Salva', 'vacunas', '0000-00-00 00:00:00'),
(4, 'Salva', 'DPI 3441418292205', '0000-00-00 00:00:00'),
(5, 'Salva', 'DPI 344141829220', '0000-00-00 00:00:00'),
(6, 'Salva', 'Vajshshs', '0000-00-00 00:00:00'),
(7, 'Salva', 'vacunas', '0000-00-00 00:00:00'),
(8, 'Salva', 'vacunas', '5/06/2021 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `pacientes`
--

CREATE TABLE `pacientes` (
  `vac_id` int(11) NOT NULL,
  `vac_nombres` varchar(100) NOT NULL,
  `vac_apellidos` varchar(100) NOT NULL,
  `vac_vacuna` varchar(100) NOT NULL,
  `vac_dosis` int(11) NOT NULL,
  `vac_direccion` varchar(150) NOT NULL,
  `vac_telefono` varchar(45) DEFAULT NULL,
  `vac_celular` varchar(45) CHARACTER SET armscii8 NOT NULL,
  `vac_DPI` bigint(20) NOT NULL,
  `vac_fechanac` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pacientes`
--

INSERT INTO `pacientes` (`vac_id`, `vac_nombres`, `vac_apellidos`, `vac_vacuna`, `vac_dosis`, `vac_direccion`, `vac_telefono`, `vac_celular`, `vac_DPI`, `vac_fechanac`) VALUES
(1, 'José', 'García', 'MODERNA', 2, '3ra Av B 4-85 Zona 17, Ciudad de Guatemala', '23557700', '57489944', 1474741230102, '1996-05-05'),
(2, 'María José', 'García', 'Sputnik V', 2, '3ra Av  14-45 Zona 11, Ciudad de Guatemala', '23557700', '57489944', 1233758230101, '1996-01-05'),
(3, 'Marlon', 'Pinto', 'PFIZER', 1, 'La frontera', '76320099', '55664321', 1234123452209, '1996-01-05'),
(4, 'Carlos', 'Martínez', 'Pfizer', 1, '2da Av 34-12c Zona 12, Ciudad de Guatemala', '78459840', '57433182', 3441418292205, '1996-06-06');

-- --------------------------------------------------------

--
-- Table structure for table `vacunas`
--

CREATE TABLE `vacunas` (
  `id` int(11) NOT NULL,
  `nombre_vacuna` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vacunas`
--

INSERT INTO `vacunas` (`id`, `nombre_vacuna`) VALUES
(1, 'MODERNA'),
(2, 'Sputnik V'),
(3, 'PFIZER');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `consultas`
--
ALTER TABLE `consultas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pacientes`
--
ALTER TABLE `pacientes`
  ADD PRIMARY KEY (`vac_id`),
  ADD UNIQUE KEY `vac_DPI_UNIQUE` (`vac_DPI`);

--
-- Indexes for table `vacunas`
--
ALTER TABLE `vacunas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `consultas`
--
ALTER TABLE `consultas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `pacientes`
--
ALTER TABLE `pacientes`
  MODIFY `vac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `vacunas`
--
ALTER TABLE `vacunas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
