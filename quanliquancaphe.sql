CREATE DATABASE QLQUANCAPHE


USE QLQUANCAPHE


-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL ,
	status NVARCHAR(100) NOT NULL DEFAULT N'Trong'	-- Trống || Có người
)

set identity_insert TableFood off
set identity_insert QLQUANCAPHE.dbo.TableFood on


insert into TableFood(id,name,status) values(001,'Ban 1','Trong')
insert into TableFood(id,name,status) values(002,'Ban 2','Co nguoi')
insert into TableFood(id,name,status) values(003,'Ban 3','Trong')
insert into TableFood(id,name,status) values(004,'Ban 4','Co nguoi')
insert into TableFood(id,name,status) values(005,'Ban 5','Trong')
insert into TableFood(id,name,status) values(006,'Ban 6','Co nguoi')
insert into TableFood(id,name,status) values(007,'Ban 7','Co nguoi')
insert into TableFood(id,name,status) values(008,'Ban 8','Trong')
insert into TableFood(id,name,status) values(009,'Ban 9','Co nguoi')
insert into TableFood(id,name,status) values(010,'Ban 10','Trong')
insert into TableFood(id,name,status) values(011,'Ban 11','Co nguoi')
insert into TableFood(id,name,status) values(012,'Ban 12','Co nguoi')
insert into TableFood(id,name,status) values(013,'Ban 13','Trong')
---tang2 quan ca phe
insert into TableFood(id,name,status) values(014,'Ban 14','Trong')
insert into TableFood(id,name,status) values(015,'Ban 15','Co nguoi')
insert into TableFood(id,name,status) values(016,'Ban 16','Trong')
insert into TableFood(id,name,status) values(017,'Ban 17','Trong')
insert into TableFood(id,name,status) values(018,'Ban 18','Co nguoi')
insert into TableFood(id,name,status) values(019,'Ban 19','Co nguoi')
insert into TableFood(id,name,status) values(020,'Ban 20','Co nguoi')
insert into TableFood(id,name,status) values(021,'Ban 21','Trong')
insert into TableFood(id,name,status) values(022,'Ban 22','Co nguoi')
insert into TableFood(id,name,status) values(023,'Ban 23','Trong')



select *from TableFood where id>013
select *from TableFood



CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Kter',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
GO



CREATE TABLE FoodandDrink
(
	id INT IDENTITY PRIMARY KEY,
	Tenmon NVARCHAR(100) NOT NULL DEFAULT N'Chua dat ten',
	idCategory INT NOT NULL,---TRÀ:1,COFFEE:2,SINHTO:3.THUCAN:4
	price FLOAT NOT NULL DEFAULT 0,
	dvt nvarchar(10) not null default N'chiec',	
)
go

drop table FoodandDrink

alter table FoodandDrink
add CONSTRAINT CHECK_CATEGORY
CHECK(idCategory='1'or idCategory='2'or idCategory='3' or idCategory='4')

alter table FoodandDrink
add CONSTRAINT CHECK_dvt
CHECK(dvt='chiec'or dvt='ly'or dvt='dia'or dvt='xau')

ALTER TABLE FoodandDrink
drop constraint CHECK_CATEGORY

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO
drop table Bill
-----insert Bill
set identity_insert dbo.Bill off
insert into Bill(id,DateCheckIn,DateCheckOut,idTable,status) values('01','2002-12-12','2002-12-12','20','1')
insert into Bill(id,DateCheckIn,DateCheckOut,idTable,status) values('02','2002-12-13','2002-12-13','20','1')
insert into Bill(id,DateCheckIn,DateCheckOut,idTable,status) values('03','2002-12-14','2002-12-14','20','1')
insert into Bill(id,DateCheckIn,DateCheckOut,idTable,status) values('04','2002-12-15','2002-12-15','20','1')
insert into Bill(id,DateCheckIn,DateCheckOut,idTable,status) values('05','2002-12-16','2002-12-16','20','1')
insert into Bill(id,DateCheckIn,DateCheckOut,idTable,status) values('06','2002-12-21','2002-12-21','20','1')

select * from Bill

CREATE TABLE BillInfo
(
	
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	soluong INT NOT NULL DEFAULT 0,	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY(idFood) REFERENCES dbo.FoodandDrink(id),
)
drop table BillInfo
----insert dữ liệu trong BillInfo
set identity_insert BillInfo on
insert into dbo.BillInfo(idBill,idFood,soluong) values ('01','01','2')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('01','02','2')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('01','03','1')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('02','14','2')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('03','15','1')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('03','16','1')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('04','21','2')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('05','22','2')
insert into dbo.BillInfo(idBill,idFood,soluong) values ('06','35','2')




select *from BillInfo



INSERT INTO Account VALUES('K9','Admin','1','1')
INSERT INTO Account VALUES('Nguyen Le Thanh','nhanvien1','123','0')
INSERT INTO Account VALUES('NT nghia','nhanvien2','123','0')
INSERT INTO Account VALUES('Le Hoang Thien','nhanvien3','123','0')
INSERT INTO Account VALUES('Nguyen Thanh Trung','nhanvien4','123','0')
INSERT INTO Account VALUES('Nguyen Kim Chi','nhanvien5','123','0')
INSERT INTO Account VALUES('NGuyen Trung Tin','nhanvien6','123','0')
INSERT INTO Account VALUES('Tran Hao Nam','nhanvien7','123','0')

select *from Account

select Type from Account where UserName='K9'


---ADDFOOD:category1
set identity_insert dbo.FoodandDrink on 
INSERT into FoodandDrink(id,Tenmon,idCategory,price,dvt) values ('01','Ca vien chien','4','10000','XAU')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('02','Tom vien chien','4','10000','xau')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('03','Bo vien chien','4','10000','xau')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('04','Banh mi ngot','4','7000','chiec')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('05','Hoanh thanh','4','10000','xau')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('06','Ha cao','4','15000','dia')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('07','Mi trung','4','15000','dia')

---ADDDRINK	
INSERT into FoodandDrink(id,Tenmon,idCategory,price,dvt) values ('08','Oolong Milk Tea','1','45000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('09','Tra dao','1','25000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('10','Tra nhan','1','25000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('11','Tra lai','1','22000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('12','Tra vai-hat sen','1','25000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('13','Tra thao mon','1','30000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('14','Tra Cocktail','1','30000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('15','Tra Dao Sua','1','30000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('16','Tra Gung','1','25000','ly')
---Hong tra
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('17','Hong Tra Chanh','1','27000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('18','Hong Tra Vai','1','27000','ly')
---tra
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('19','Tra Hoa Hong','1','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('20','Tra Xanh Latte','1','35000','ly')

--da xay-40k
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('21','Tra Xanh Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('22','Tra Dao Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('23','Tra Xanh Xay Cung Hanh Nhan','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('24','Capuchino Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('25','Ca Phe Bac Ha Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('26','Tra Hoa Hong','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('27','Ca Phe Xay Cung Banh Oreo','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('28','Socola Ca Phe Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('29','Caramel Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('30','Socola Trang Da Xay','2','40000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('31','Ca Phe Sua','2','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('32','Ca Phe Den','2','30000','ly')


---sinhto nuoc ep.
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('33','Nuoc Tao Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('34','Nuoc Tao Va Dau Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('35','Buoi Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('36','Sinh To Bo','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('37','Dau Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('38','Thom Va Dau Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('39','Cam Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('40','Nuoc Oi Ep','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('41','Sinh To Dau','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('42','Sinh To Trai Cay Nhiet Doi','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('43','Sinh To Chuoi-Dau','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('44','Vitamin C(Xoai,Cam,Chanh Day)','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('45','Sinh To Xoai','3','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('46','Sinh To Chanh','3','35000','ly')
--add them caphe
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('47','Capuchino','2','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('48','Ca Phe Latte','2','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('49','Ca Phe Vanilla','2','35000','ly')
insert into FoodandDrink(id,Tenmon,idCategory,price,dvt) values('50','Ca Phe Caramel','2','35000','ly')

select * from FoodandDrink where idCategory = 4

select * from FoodandDrink

