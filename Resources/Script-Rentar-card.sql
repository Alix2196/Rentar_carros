USE renta_automoviles;
DROP TABLE IF EXISTS `reservas`;   

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
    `id_cliente` INT AUTO_INCREMENT PRIMARY KEY,
    `documento` INT,
    `ciudad` VARCHAR(100),	
    `nombre` VARCHAR(100),
    `email` VARCHAR(100) UNIQUE,
    `telefono` VARCHAR(20),
    `direccion` VARCHAR(100),
    `fecha_nacimiento` DATE,
    `fecha_creacion` DATE,
    `fecha_actualizacion` DATE
);

DROP TABLE IF EXISTS `vehiculos`;
CREATE TABLE `vehiculos` (
    `id_vehiculo` INT AUTO_INCREMENT PRIMARY KEY,
    `marca` VARCHAR(100),
    `color` VARCHAR(100),
    `placa` VARCHAR(20) UNIQUE,
    `cilindraje` INT,
    `modelo` INT,
    `precio` INT,
    `tipo` VARCHAR(50)
);

DROP TABLE IF EXISTS `tipo_pagos`;
CREATE TABLE `tipo_pagos` (
    `id_pago` INT AUTO_INCREMENT PRIMARY KEY,
    `tipo` VARCHAR(50)
);

DROP TABLE IF EXISTS `estado_reserva`;
CREATE TABLE `estado_reserva` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `tipo` VARCHAR(25)
    
);

DROP TABLE IF EXISTS `solicitudes`;
CREATE TABLE `solicitudes` (
    `id_solicitud` INT AUTO_INCREMENT PRIMARY KEY,
    `estado` VARCHAR(50),
    `fecha_creacion` DATE,
    `fecha_actualizacion` DATE,
    `descripcion` VARCHAR(255)
);

DROP TABLE IF EXISTS `reservas`;
CREATE TABLE `reservas` (
    `id_reserva` INT AUTO_INCREMENT PRIMARY KEY,
    `id_solicitudes` INT,
    `estado` INT,
    `id_vehiculo` INT,
    `id_cliente` INT,
    `fecha_inicio` DATE,
    `fecha_fin` DATE,
    `tipo_pago` INT,
    `valor_pago` INT,
  	FOREIGN KEY (`estado`) REFERENCES `estado_reserva`(`id`),
    FOREIGN KEY (`id_cliente`) REFERENCES `clientes`(`id_cliente`),
    FOREIGN KEY (`id_vehiculo`) REFERENCES `vehiculos`(`id_vehiculo`),
    FOREIGN KEY (`tipo_pago`) REFERENCES `tipo_pagos`(`id_pago`),
    FOREIGN KEY (`id_solicitudes`) REFERENCES `solicitudes`(`id_solicitud`)
);


INSERT INTO vehiculos (marca, color, placa, cilindraje, modelo, precio, tipo)
VALUES 
('Hyundai', 'Plateado', 'MNO345', 2000, 2023, 53000, 'Sedán'),
('Kia', 'Blanco', 'PQR678', 1800, 2022, 48000, 'Hatchback'),
('Volkswagen', 'Negro', 'STU901', 2200, 2021, 55000, 'SUV'),
('BMW', 'Azul', 'VWX234', 2500, 2024, 70000, 'SUV'),
('Mercedes-Benz', 'Gris', 'YZA567', 2400, 2023, 65000, 'Sedán'),
('Audi', 'Rojo', 'BCD890', 2000, 2022, 58000, 'Coupe'),
('Tesla', 'Blanco', 'EFG123', 0, 2022, 80000, 'Eléctrico'),
('Mazda', 'Negro', 'HIJ456', 2000, 2023, 53000, 'SUV'),
('Jeep', 'Verde', 'KLM789', 2800, 2021, 60000, 'Camioneta'),
('Subaru', 'Gris', 'NOP012', 2500, 2024, 65000, 'SUV'),
('Volvo', 'Azul', 'QRS345', 2200, 2022, 58000, 'Sedán'),
('Lexus', 'Blanco', 'TUV678', 2000, 2023, 62000, 'SUV'),
('Ford', 'Negro', 'WXY901', 2300, 2021, 55000, 'Pickup'),
('Chevrolet', 'Rojo', 'ZAB234', 2100, 2024, 59000, 'Sedán'),
('Toyota', 'Plateado', 'BCD567', 1900, 2022, 52000, 'Hatchback');


INSERT INTO tipo_pagos (tipo)
VALUES 
('Tarjeta de crédito'),
('Transferencia bancaria'),
('destino');

INSERT INTO estado_reserva (id, tipo)
VALUES 
(1, 'Activa'),
(2, 'Cancelada'),
(3, 'Exploracion');







