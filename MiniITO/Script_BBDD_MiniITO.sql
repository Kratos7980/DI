-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`FACTURA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`FACTURA` (
  `IDFACTURA` INT NOT NULL,
  `NUMFACTURA` VARCHAR(16) NOT NULL,
  `DESCFACTURA` VARCHAR(1024) NOT NULL,
  `IMPORTE` FLOAT NOT NULL,
  PRIMARY KEY (`IDFACTURA`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`PROYECTO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`PROYECTO` (
  `IDPROYECTO` INT NOT NULL AUTO_INCREMENT,
  `CODIGOPROY` VARCHAR(32) NOT NULL,
  `NOMBREPROY` VARCHAR(32) NOT NULL,
  `DESCPROY` VARCHAR(1024) NOT NULL,
  `PRESUPUESTO` FLOAT NOT NULL,
  `IDFACTURA` INT NULL,
  PRIMARY KEY (`IDPROYECTO`),
  INDEX `fk_PROYECTO_FACTURA1_idx` (`IDFACTURA` ASC) VISIBLE,
  UNIQUE INDEX `CODIGOPROY_UNIQUE` (`CODIGOPROY` ASC) VISIBLE,
  CONSTRAINT `fk_PROYECTO_FACTURA1`
    FOREIGN KEY (`IDFACTURA`)
    REFERENCES `mydb`.`FACTURA` (`IDFACTURA`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`USUARIO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`USUARIO` (
  `IDUSUARIO` INT NOT NULL AUTO_INCREMENT,
  `NOMBREUSUARIO` VARCHAR(32) NOT NULL,
  `PASSUSUARIO` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`IDUSUARIO`),
  UNIQUE INDEX `NOMBREUSUARIO_UNIQUE` (`NOMBREUSUARIO` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ROL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ROL` (
  `IDROL` INT NOT NULL AUTO_INCREMENT,
  `NOMBREROL` VARCHAR(64) NOT NULL,
  `DESCROL` VARCHAR(1024) NOT NULL,
  PRIMARY KEY (`IDROL`))
ENGINE = InnoDB;

INSERT INTO `mydb`.`rol` (`NOMBREROL`, `DESCROL`) VALUES ('JEFE PROYECTO', 'Encargado principal');
INSERT INTO `mydb`.`rol` (`NOMBREROL`, `DESCROL`) VALUES ('PROGRAMADOR', 'Desarrollador del proyecto');
INSERT INTO `mydb`.`rol` (`NOMBREROL`, `DESCROL`) VALUES ('DISEÑADOR GRAFICO', 'Diseñador de la interfaz gráfica del proyecto');
INSERT INTO `mydb`.`rol` (`NOMBREROL`, `DESCROL`) VALUES ('TESTER', 'Encargado de propar el software en busca de errores');
-- -----------------------------------------------------
-- Table `mydb`.`EMPLEADO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`EMPLEADO` (
  `IDEMPLEADO` INT NOT NULL AUTO_INCREMENT,
  `NOMBREEMP` VARCHAR(64) NOT NULL,
  `APELLIDOS` VARCHAR(32) NOT NULL,
  `CSR` FLOAT NOT NULL,
  `IDUSUARIO` INT NOT NULL,
  `IDROL` INT NOT NULL,
  PRIMARY KEY (`IDEMPLEADO`),
  INDEX `fk_EMPLEADO_USUARIO_idx` (`IDUSUARIO` ASC) VISIBLE,
  INDEX `fk_EMPLEADO_ROL1_idx` (`IDROL` ASC) VISIBLE,
  CONSTRAINT `fk_EMPLEADO_USUARIO`
    FOREIGN KEY (`IDUSUARIO`)
    REFERENCES `mydb`.`USUARIO` (`IDUSUARIO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_EMPLEADO_ROL1`
    FOREIGN KEY (`IDROL`)
    REFERENCES `mydb`.`ROL` (`IDROL`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`PROYECTO_has_EMPLEADO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`PROYECTO_has_EMPLEADO` (
  `IDPROYECTO` INT NOT NULL,
  `IDEMPLEADO` INT NOT NULL,
  `FECHA` DATE NOT NULL,
  `COSTES` FLOAT NOT NULL,
  `HORAS` INT NOT NULL,
  PRIMARY KEY (`IDPROYECTO`, `IDEMPLEADO`, `FECHA`),
  INDEX `fk_PROYECTO_has_EMPLEADO_EMPLEADO1_idx` (`IDEMPLEADO` ASC) VISIBLE,
  INDEX `fk_PROYECTO_has_EMPLEADO_PROYECTO1_idx` (`IDPROYECTO` ASC) VISIBLE,
  CONSTRAINT `fk_PROYECTO_has_EMPLEADO_PROYECTO1`
    FOREIGN KEY (`IDPROYECTO`)
    REFERENCES `mydb`.`PROYECTO` (`IDPROYECTO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PROYECTO_has_EMPLEADO_EMPLEADO1`
    FOREIGN KEY (`IDEMPLEADO`)
    REFERENCES `mydb`.`EMPLEADO` (`IDEMPLEADO`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
