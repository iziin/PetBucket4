CREATE TABLE Customer (
  [id] INT NOT NULL IDENTITY,
  [first_name] VARCHAR(45) NOT NULL,
  [surname] VARCHAR(45) NOT NULL,
  [age] INT NOT NULL,
  [home_phone] VARCHAR(45) NULL,
  [mobile_phone] VARCHAR(45) NULL,
  [unit_no] VARCHAR(45) NULL,
  [house_no] VARCHAR(45) NULL,
  [street] VARCHAR(255) NULL,
  [city] VARCHAR(45) NULL,
  [state] VARCHAR(3) NULL,
  [postcode] VARCHAR(5) NULL,
  [email] VARCHAR(255) NOT NULL,
  [password] VARCHAR(255) NOT NULL,
  [last_logged_in] DATETIME2(0) NULL,
  [created] DATETIME2(0) NOT NULL,
  PRIMARY KEY ([id]))
;


-- -----------------------------------------------------
-- Table `PetBucket`.`Pet`
-- -----------------------------------------------------
CREATE TABLE Pet (
  [id] INT NOT NULL IDENTITY,
  [name] VARCHAR(255) NULL,
  [size] VARCHAR(45) NULL,
  [animal] VARCHAR(45) NOT NULL,
  [active] SMALLINT NULL,
  [indoors_safe] SMALLINT NULL,
  [under_13_safe] SMALLINT NULL,
  [customer_id] INT NULL,
  [created] DATETIME2(0) NOT NULL,
  [last_active] DATETIME2(0) NULL,
  PRIMARY KEY ([id]))
;



-- -----------------------------------------------------
-- Table `PetBucket`.`Staff`
-- -----------------------------------------------------
CREATE TABLE Staff (
  [id] INT NOT NULL IDENTITY,
  [first_name] VARCHAR(255) NULL,
  [surname] VARCHAR(255) NULL,
  [email] VARCHAR(255) NOT NULL,
  [password] VARCHAR(255) NOT NULL,
  [created] DATETIME2(0) NOT NULL,
  [last_logged_in] DATETIME2(0) NULL,
  PRIMARY KEY ([id]))
;


-- -----------------------------------------------------
-- Table `PetBucket`.`Appointment`
-- -----------------------------------------------------
CREATE TABLE Appointment (
  [id] INT NOT NULL IDENTITY,
  [number_of_pets] INT NULL DEFAULT 1,
  [pet_id] INT NULL,
  [service] INT NOT NULL,
  [entry_instructions] VARCHAR(255) NULL,
  [care_instructions] VARCHAR(255) NULL,
  [inspection_visit_date] DATE NULL,
  [start_time] DATETIME2(0) NULL,
  [end_time] DATETIME2(0) NULL,
  [created] DATETIME2(0) NOT NULL,
  [food] VARCHAR(255) NULL DEFAULT 'stock',
  PRIMARY KEY ([id]))
;


-- -----------------------------------------------------
-- Table `PetBucket`.`Review`
-- -----------------------------------------------------
CREATE TABLE Review (
  [id] INT NOT NULL IDENTITY,
  [customer_id] INT NOT NULL,
  [review_text] VARCHAR(max) NULL,
  [rating] INT NOT NULL,
  [created] DATETIME2(0) NOT NULL,
  PRIMARY KEY ([id]))
;


/* SET SQL_MODE=@OLD_SQL_MODE; */
/* SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS; */
/* SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS; */
