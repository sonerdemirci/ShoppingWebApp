-- Database oluşturma
CREATE DATABASE ShoppingWebDB;

-- Oluşturulan Database kullanma
USE ShoppingWebDB;

-- Roles Tablosu
-- RoleID: 1-Admin, 2-User, 3-Guest -> düzenleme yetkisi sadece adminde olacak şekilde ayarlanabilir en son
CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(100)
);

-- Users Tablosu
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(255),
    Email VARCHAR(255),
    Password VARCHAR(255),
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- Categories Tablosu
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100)
);

-- Products Tablosu
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(255),
    Price DECIMAL(10, 2),
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);



-- Roles Tablosuna Kayıtlar Ekleme
INSERT INTO Roles (RoleName) 
VALUES 
('Admin'),
('User'),
('Guest');


INSERT INTO Categories (CategoryName) 
VALUES 
('Elektronik'),
('Moda'),
('Yiyecek');


INSERT INTO Users (FullName, Email, Password, RoleID) 
VALUES 
('Ahmet Yılmaz', 'ahmet@gmail.com', 'password123', 1),  -- Admin
('Ayşe Demir', 'ayse@hotmail.com', 'password123', 2),    -- User
('Mehmet Kaya', 'mehmet@gmail.com', 'password123', 3);  -- Guest

-- Products Tablosuna Örnek Kayıtlar Ekleme
INSERT INTO Products (ProductName, Price, CategoryID) 
VALUES 
('Laptop', 5500.00, 1),  -- Elektronik
('T-shirt', 120.00, 2),  -- Moda
('Apple', 8.50, 3);      -- Yiyecek

