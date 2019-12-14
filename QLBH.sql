CREATE DATABASE QLBH
USE QLBH

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TABLEFOOD
(
	ID INT IDENTITY PRIMARY KEY,  -- mã bàn
	NAME NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên', -- tên bàn
	STATUS NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO

CREATE TABLE ACCOUNT
(
	USERNAME NVARCHAR(100) PRIMARY KEY,	    -- tên tài khoản
	DISPLAYNAME NVARCHAR(100) NOT NULL DEFAULT N'Kter',    -- tên hiển thị
	PASSWORD NVARCHAR(1000) NOT NULL DEFAULT 0,   -- mật khẩu
	TYPE INT NOT NULL  DEFAULT 0 -- 1: admin && 0:staff
)
GO

CREATE TABLE FOODCATEGORY
(
	ID INT IDENTITY PRIMARY KEY,
	NAME NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE FOOD
(
	ID INT IDENTITY PRIMARY KEY,
	NAME NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	IDCATEGORY INT NOT NULL,
	PRICE FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (IDCATEGORY) REFERENCES dbo.FOODCATEGORY(ID)
)
GO

CREATE TABLE BILL
(
	ID INT IDENTITY PRIMARY KEY,
	DATECHECKIN DATE NOT NULL DEFAULT GETDATE(),
	DATECHECKOUT DATE,
	IDTABLE INT NOT NULL,
	STATUS INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán
	
	FOREIGN KEY (IDTABLE) REFERENCES dbo.TABLEFOOD(ID)
)
GO

CREATE TABLE BILLINFO
(
	ID INT IDENTITY PRIMARY KEY,
	IDBILL INT NOT NULL,
	IDFOOD INT NOT NULL,
	COUNT INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (IDBILL) REFERENCES dbo.BILL(ID),
	FOREIGN KEY (IDFOOD) REFERENCES dbo.FOOD(ID)
)
GO


---------------------------------------------------------------
INSERT INTO dbo.ACCOUNT(USERNAME,DISPLAYNAME,PASSWORD,TYPE) 
VALUES (N'thanhlenguyen',N'Thanh',N'1',1)

INSERT INTO dbo.ACCOUNT(USERNAME,DISPLAYNAME,PASSWORD,TYPE) 
VALUES (N'staff',N'staff',N'1',0)

SELECT * FROM ACCOUNT 
SELECT DISPLAYNAME FROM ACCOUNT
GO

CREATE PROC USP_GETACCOUNTBYUSERNAME
@USERNAME NVARCHAR(100)
AS
BEGIN
 SELECT * FROM ACCOUNT WHERE USERNAME = @USERNAME
END
GO

EXEC USP_GETACCOUNTBYUSERNAME @USERNAME = N'thanhlenguyen'
GO

CREATE PROC USP_LOGIN
@USERNAME NVARCHAR(100), @PASSWORD NVARCHAR(100)
AS
BEGIN
 SELECT * FROM ACCOUNT WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD
END
GO

select * from QLBH.information_schema.routines where routine_type = 'PROCEDURE'

DECLARE @i int = 0 
WHILE @i<10
BEGIN
	INSERT TABLEFOOD (NAME) VALUES (N'Bàn' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO

SELECT * FROM TABLEFOOD
--DELETE  FROM TABLEFOOD WHERE NAME = 'Bàn0'
DROP TABLE TABLEFOOD
DELETE TOP(13) FROM TABLEFOOD
DBCC CHECKIDENT ('dbo.TABLEFOOD', RESEED, 0)
GO

--
CREATE PROC USP_GETTABLELIST
AS SELECT * FROM TABLEFOOD
GO

EXEC USP_GETTABLELIST
UPDATE TABLEFOOD SET STATUS = 'Có người' WHERE ID = 5


--------------------------- thêm dữ liệu
-- thêm bàn

set identity_insert dbo.TableFood on
set identity_insert dbo.TableFood off

insert into TABLEFOOD(ID,NAME,STATUS) values(1,N'Bàn 1',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(2,N'Bàn 2',N'Có người')
insert into TABLEFOOD(ID,NAME,STATUS) values(3,N'Bàn 3',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(4,N'Bàn 4',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(5,N'Bàn 5',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(6,N'Bàn 6',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(7,N'Bàn 7',N'Có người')
insert into TABLEFOOD(ID,NAME,STATUS) values(8,N'Bàn 8',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(9,N'Bàn 9',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(10,N'Bàn 10',N'Trống')
insert into TABLEFOOD(ID,NAME,STATUS) values(11,N'Bàn 11',N'Có người')
insert into TABLEFOOD(ID,NAME,STATUS) values(12,N'Bàn 12',N'Có người')
insert into TABLEFOOD(ID,NAME,STATUS) values(13,N'Bàn 13',N'Trống')

SELECT * FROM TABLEFOOD
DELETE TOP(13) FROM TABLEFOOD


-- idcategory : 1-Tra , 2-DaXay, 3-SinhTo, 4-Cafe, 5-DoAn
set identity_insert FOODCATEGORY on
set identity_insert FOODCATEGORY off

INSERT FOODCATEGORY(ID,NAME) VALUES (1,N'Trà')
INSERT FOODCATEGORY(ID,NAME) VALUES (2,N'Đá xay')
INSERT FOODCATEGORY(ID,NAME) VALUES (3,N'Sinh tố')
INSERT FOODCATEGORY(ID,NAME) VALUES (4,N'Cafe')
INSERT FOODCATEGORY(ID,NAME) VALUES (5,N'Đồ ăn')

SELECT * FROM FOODCATEGORY 
--thêm nước uống và đồ ăn

set identity_insert dbo.Food on 

-- id: 1-Tra
INSERT into Food(id,Name,idCategory,price) values ('01','Oolong Milk Tea','1','45000')
insert into Food(id,Name,idCategory,price) values('02','Tra dao','1','25000')
insert into Food(id,Name,idCategory,price) values('03','Tra nhan','1','25000')
insert into Food(id,Name,idCategory,price) values('04','Tra lai','1','22000')
insert into Food(id,Name,idCategory,price) values('05','Tra vai-hat sen','1','25000')
insert into Food(id,Name,idCategory,price) values('06','Tra thao mon','1','30000')
insert into Food(id,Name,idCategory,price) values('07','Tra Cocktail','1','30000')
insert into Food(id,Name,idCategory,price) values('08','Tra Dao Sua','1','30000')
insert into Food(id,Name,idCategory,price) values('09','Tra Gung','1','25000')
insert into Food(id,Name,idCategory,price) values('10','Hong Tra Chanh','1','27000')
insert into Food(id,Name,idCategory,price) values('11','Hong Tra Vai','1','27000')
insert into Food(id,Name,idCategory,price) values('12','Tra Hoa Hong','1','35000')
insert into Food(id,Name,idCategory,price) values('13','Tra Xanh Latte','1','35000')


--id-2 da xay - 40k
insert into Food(id,Name,idCategory,price) values('14','Tra Xanh Da Xay','2','40000')
insert into Food(id,Name,idCategory,price) values('15','Tra Dao Da Xay','2','40000')
insert into Food(id,Name,idCategory,price) values('16','Tra Xanh Xay Cung Hanh Nhan','2','40000')
insert into Food(id,Name,idCategory,price) values('17','Capuchino Da Xay','2','40000')
insert into Food(id,Name,idCategory,price) values('18','Ca Phe Bac Ha Da Xay','2','40000')
insert into Food(id,Name,idCategory,price) values('19','Tra Hoa Hong','2','40000')
insert into Food(id,Name,idCategory,price) values('20','Ca Phe Xay Cung Banh Oreo','2','40000')
insert into Food(id,Name,idCategory,price) values('21','Socola Ca Phe Da Xay','2','40000')
insert into Food(id,Name,idCategory,price) values('22','Caramel Da Xay','2','40000')
insert into Food(id,Name,idCategory,price) values('23','Socola Trang Da Xay','2','40000')

--- id-3   sinhto nuoc ep.
insert into Food(id,Name,idCategory,price) values('24','Nuoc Tao Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('25','Nuoc Tao Va Dau Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('26','Buoi Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('27','Sinh To Bo','3','35000')
insert into Food(id,Name,idCategory,price) values('28','Dau Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('29','Thom Va Dau Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('30','Cam Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('31','Nuoc Oi Ep','3','35000')
insert into Food(id,Name,idCategory,price) values('32','Sinh To Dau','3','35000')
insert into Food(id,Name,idCategory,price) values('33','Sinh To Trai Cay Nhiet Doi','3','35000')
insert into Food(id,Name,idCategory,price) values('34','Sinh To Chuoi-Dau','3','35000')
insert into Food(id,Name,idCategory,price) values('35','Vitamin C(Xoai,Cam,Chanh Day)','3','35000')
insert into Food(id,Name,idCategory,price) values('36','Sinh To Xoai','3','35000')
insert into Food(id,Name,idCategory,price) values('37','Sinh To Chanh','3','35000')

--id 4 -- caphe
insert into Food(id,Name,idCategory,price) values('38','Capuchino','4','35000')
insert into Food(id,Name,idCategory,price) values('39','Ca Phe Latte','4','35000')
insert into Food(id,Name,idCategory,price) values('40','Ca Phe Vanilla','4','35000')
insert into Food(id,Name,idCategory,price) values('41','Ca Phe Caramel','4','35000')
insert into Food(id,Name,idCategory,price) values('42','Ca Phe Sua','4','35000')
insert into Food(id,Name,idCategory,price) values('43','Ca Phe Den','4','30000')

--id 5 -- thuc an
INSERT into Food(id,Name,idCategory,price) values ('44','Ca vien chien','5','10000')
insert into Food(id,Name,idCategory,price) values('45','Tom vien chien','5','10000')
insert into Food(id,Name,idCategory,price) values('46','Bo vien chien','5','10000')
insert into Food(id,Name,idCategory,price) values('47','Banh mi ngot','5','7000')
insert into Food(id,Name,idCategory,price) values('48','Hoanh thanh','5','10000')
insert into Food(id,Name,idCategory,price) values('49','Ha cao','5','15000')
insert into Food(id,Name,idCategory,price) values('50','Mi trung','5','15000')

SELECT * FROM FOOD
DELETE TOP(50) From FOOD

SELECT * FROM BILL
SELECT * FROM BILLINFO
SELECT * FROM TABLEFOOD

-- thêm bill
INSERT INTO BILL(DATECHECKIN,DATECHECKOUT,IDTABLE,STATUS) VALUES (GETDATE(),NULL,2,0)
INSERT INTO BILL(DATECHECKIN,DATECHECKOUT,IDTABLE,STATUS) VALUES (GETDATE(),GETDATE(),7,1)
INSERT INTO BILL(DATECHECKIN,DATECHECKOUT,IDTABLE,STATUS) VALUES (GETDATE(),NULL,11,0)
INSERT INTO BILL(DATECHECKIN,DATECHECKOUT,IDTABLE,STATUS) VALUES (GETDATE(),GETDATE(),12,1)

set identity_insert BILLINFO on 
INSERT INTO BILLINFO(ID,IDBILL,IDFOOD,COUNT) VALUES (1,1,12,2)
INSERT INTO BILLINFO(ID,IDBILL,IDFOOD,COUNT) VALUES (2,2,49,1)
INSERT INTO BILLINFO(ID,IDBILL,IDFOOD,COUNT) VALUES (3,3,15,3)
INSERT INTO BILLINFO(ID,IDBILL,IDFOOD,COUNT) VALUES (4,4,1,2)


select * from BILLINFO
DELETE TOP(4) FROM BILLINFO