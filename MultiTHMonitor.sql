use master
go
if exists(select * from sysdatabases where name='MultiTHMonitorDB')
drop database MultiTHMonitorDB
go
create database  MultiTHMonitorDB
on primary
(
    name='MultiTHMonitorDB_data',
	filename='D:\DB\MultiTHMonitorDB_data.mdf',
	size=100MB,
	filegrowth=50MB
)
log on
(
   name='MultiTHMonitorDB_log',
	filename='D:\DB\MultiTHMonitorDB_log.ldf',
	size=100MB,
	filegrowth=50MB
)
go

use MultiTHMonitorDB
go

--创建《用户表》
if exists(select * from sysobjects where name='SysAdmin')
drop table SysAdmin
go
create table SysAdmin
(
      LoginId int identity(10000,1) primary key, --用户Id
      LoginName varchar(100) not null,
      LoginPwd varchar(20) not null,
      ParamSet bit not null,
      Recipe bit not null,
      HistoryLog bit not null,
      HistoryTrend bit not null,
      UserManage   bit not null
)
go

insert into SysAdmin(LoginName,LoginPwd,ParamSet,Recipe,HistoryLog,HistoryTrend,UserManage) values('Admin','123',1,1,1,1,1)

Select * from  SysAdmin

if exists(select * from sysobjects where name='SysLog')
drop table SysLog
go
create table SysLog (
    Id int identity(1,1) primary key, 
    InsertTime varchar(50) not null,
    Note varchar(200) not null,
    AlarmType  varchar(20) not null,
    Operator varchar(20) not null,
    VarName varchar(20) not null
);

if exists(select * from sysobjects where name='ActualData')
drop table ActualData
go
create table ActualData (
    Id int identity(1,1) primary key, 
    InsertTime varchar(50) not null,
    Station1Temp varchar(20) not null,
    Station1Humidity varchar(20) not null,
    Station2Temp varchar(20) not null,
    Station2Humidity varchar(20) not null,
	Station3Temp varchar(20) not null,
    Station3Humidity varchar(20) not null,
	Station4Temp varchar(20) not null,
    Station4Humidity varchar(20) not null,
	Station5Temp varchar(20) not null,
    Station5Humidity varchar(20) not null,
	Station6Temp varchar(20) not null,
    Station6Humidity varchar(20) not null,
);