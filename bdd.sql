/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     16/6/2024 08:41:50                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('credit') and o.name = 'FK_CREDIT_FK_CREDIT_CUSTOMER')
alter table credit
   drop constraint FK_CREDIT_FK_CREDIT_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('credit') and o.name = 'FK_CREDIT_FK_USERS_USERS')
alter table credit
   drop constraint FK_CREDIT_FK_USERS_USERS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('credits_details') and o.name = 'FK_CREDITS_FK_CREDIT_CREDIT')
alter table credits_details
   drop constraint FK_CREDITS_FK_CREDIT_CREDIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('credits_details') and o.name = 'FK_CREDITS_FK_CREDIT_PRODUCTS')
alter table credits_details
   drop constraint FK_CREDITS_FK_CREDIT_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('products') and o.name = 'FK_PRODUCTS_FK_PRODU_CATEGORI')
alter table products
   drop constraint FK_PRODUCTS_FK_PRODU_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('stock_adjusts') and o.name = 'FK_STOCK_AD_FK_STOCK_PRODUCTS')
alter table stock_adjusts
   drop constraint FK_STOCK_AD_FK_STOCK_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('stock_moves') and o.name = 'FK_STOCK_MO_RELATIONS_PRODUCTS')
alter table stock_moves
   drop constraint FK_STOCK_MO_RELATIONS_PRODUCTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('stock_moves') and o.name = 'FK_STOCK_MO_FK_STOCK_TRANSFER')
alter table stock_moves
   drop constraint FK_STOCK_MO_FK_STOCK_TRANSFER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('transfers') and o.name = 'FK_TRANSFER_FK_TRANS_TRANSFER')
alter table transfers
   drop constraint FK_TRANSFER_FK_TRANS_TRANSFER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('users') and o.name = 'FK_USERS_FK_USER_ROLES')
alter table users
   drop constraint FK_USERS_FK_USER_ROLES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('categories')
            and   type = 'U')
   drop table categories
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('credit')
            and   name  = 'FK_USERS_CREDIT_FK'
            and   indid > 0
            and   indid < 255)
   drop index credit.FK_USERS_CREDIT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('credit')
            and   name  = 'FK_CREDIT_CUSTOMER_FK'
            and   indid > 0
            and   indid < 255)
   drop index credit.FK_CREDIT_CUSTOMER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('credit')
            and   type = 'U')
   drop table credit
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('credits_details')
            and   name  = 'FK_CREDIT_DETAILS_PRODUCTS_FK'
            and   indid > 0
            and   indid < 255)
   drop index credits_details.FK_CREDIT_DETAILS_PRODUCTS_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('credits_details')
            and   name  = 'FK_CREDIT_DETAILS_CREDIT_FK'
            and   indid > 0
            and   indid < 255)
   drop index credits_details.FK_CREDIT_DETAILS_CREDIT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('credits_details')
            and   type = 'U')
   drop table credits_details
go

if exists (select 1
            from  sysobjects
           where  id = object_id('customer')
            and   type = 'U')
   drop table customer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('products')
            and   name  = 'FK_PRODUCT_CATEGORY_FK'
            and   indid > 0
            and   indid < 255)
   drop index products.FK_PRODUCT_CATEGORY_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('products')
            and   type = 'U')
   drop table products
go

if exists (select 1
            from  sysobjects
           where  id = object_id('roles')
            and   type = 'U')
   drop table roles
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('stock_adjusts')
            and   name  = 'FK_STOCK_ADJUST_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index stock_adjusts.FK_STOCK_ADJUST_PRODUCT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('stock_adjusts')
            and   type = 'U')
   drop table stock_adjusts
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('stock_moves')
            and   name  = 'FK_STOCK_NOVES_PRODUCT_ID'
            and   indid > 0
            and   indid < 255)
   drop index stock_moves.FK_STOCK_NOVES_PRODUCT_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('stock_moves')
            and   name  = 'FK_STOCK_MOVE_TRANSFER_FK'
            and   indid > 0
            and   indid < 255)
   drop index stock_moves.FK_STOCK_MOVE_TRANSFER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('stock_moves')
            and   type = 'U')
   drop table stock_moves
go

if exists (select 1
            from  sysobjects
           where  id = object_id('transfer_types')
            and   type = 'U')
   drop table transfer_types
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('transfers')
            and   name  = 'FK_TRANSFER_TRANSFER_TYPE_FK'
            and   indid > 0
            and   indid < 255)
   drop index transfers.FK_TRANSFER_TRANSFER_TYPE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('transfers')
            and   type = 'U')
   drop table transfers
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('users')
            and   name  = 'FK_USER_ROL_FK'
            and   indid > 0
            and   indid < 255)
   drop index users.FK_USER_ROL_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('users')
            and   type = 'U')
   drop table users
go

/*==============================================================*/
/* Table: categories                                            */
/*==============================================================*/
create table categories (
   category_id          int                  not null identity(1,1),
   category_name        varchar(100)         not null,
   category_state       bit                  not null,
   constraint PK_CATEGORIES primary key (category_id)
)
go

/*==============================================================*/
/* Table: credit                                                */
/*==============================================================*/
create table credit (
   credit_id            int                  not null identity(1,1),
   customer_id          int                  null,
   user_id              int                  null,
   customer_notes       varchar(100)         not null,
   credit_status        varchar(10)          not null,
   credit_state         bit                  not null,
   constraint PK_CREDIT primary key (credit_id)
)
go

/*==============================================================*/
/* Index: FK_CREDIT_CUSTOMER_FK                                 */
/*==============================================================*/




create nonclustered index FK_CREDIT_CUSTOMER_FK on credit (customer_id ASC)
go

/*==============================================================*/
/* Index: FK_USERS_CREDIT_FK                                    */
/*==============================================================*/




create nonclustered index FK_USERS_CREDIT_FK on credit (user_id ASC)
go

/*==============================================================*/
/* Table: credits_details                                       */
/*==============================================================*/
create table credits_details (
   credit_detail_id     int                  not null identity(1,1),
   credit_id            int                  null,
   product_id           int                  null,
   week_id              int                  null,
   credit_detail_description text                 not null,
   credit_detail_value  decimal(10,2)         not null,
   constraint PK_CREDITS_DETAILS primary key (credit_detail_id)
)
go

/*==============================================================*/
/* Index: FK_CREDIT_DETAILS_CREDIT_FK                           */
/*==============================================================*/




create nonclustered index FK_CREDIT_DETAILS_CREDIT_FK on credits_details (credit_id ASC)
go

/*==============================================================*/
/* Index: FK_CREDIT_DETAILS_PRODUCTS_FK                         */
/*==============================================================*/




create nonclustered index FK_CREDIT_DETAILS_PRODUCTS_FK on credits_details (product_id ASC)
go

/*==============================================================*/
/* Table: customer                                              */
/*==============================================================*/
create table customer (
   customer_id          int                  not null identity(1,1),
   customer_first_name  varchar(100)         not null,
   customer_last_name   varchar(100)         not null,
   customer_state       bit                  not null,
   customer_address     varchar(150)         null,
   customer_ci          varchar(15)          not null,
   customer_phone       varchar(50)          not null,
   customer_email       varchar(150)         not null,
   constraint PK_CUSTOMER primary key (customer_id)
)
go

/*==============================================================*/
/* Table: products                                              */
/*==============================================================*/
create table products (
   product_id           int                  not null identity(1,1),
   category_id          int                  null,
   product_name         varchar(100)         not null,
   product_sale_price   decimal(10,2)         not null,
   product_purchase_price decimal(10,2)         not null,
   product_img          text                 not null,
   product_stock_quantity int                  null,
   product_state        bit                  not null,
   constraint PK_PRODUCTS primary key (product_id)
)
go

/*==============================================================*/
/* Index: FK_PRODUCT_CATEGORY_FK                              */
/*==============================================================*/




create nonclustered index FK_PRODUCT_CATEGORY_FK on products (category_id ASC)
go

/*==============================================================*/
/* Table: roles                                                 */
/*==============================================================*/
create table roles (
   rol_id               int                  not null identity(1,1),
   rol_name             varchar(100)         not null,
   rol_state            bit                  not null,
   constraint PK_ROLES primary key (rol_id)
)
go

/*==============================================================*/
/* Table: stock_adjusts                                         */
/*==============================================================*/
create table stock_adjusts (
   stock_adjust_id      int                  not null identity(1,1),
   product_id           int                  null,
   stock_adjust_date    datetime             not null,
   stock_adjust_quantity int                  null,
   stock_adjust_reason  varchar(250)         not null,
   constraint PK_STOCK_ADJUSTS primary key (stock_adjust_id)
)
go

/*==============================================================*/
/* Index: FK_STOCK_ADJUST_PRODUCT_FK                          */
/*==============================================================*/




create nonclustered index FK_STOCK_ADJUST_PRODUCT_FK on stock_adjusts (product_id ASC)
go

/*==============================================================*/
/* Table: stock_moves                                           */
/*==============================================================*/
create table stock_moves (
   stock_move_id        int                  not null identity(1,1),
   product_id           int                  null,
   transfer_id          int                  null,
   stock_move_quantity  int                  null,
   stock_move_price_unit decimal(10,2)          not null,
   constraint PK_STOCK_MOVES primary key (stock_move_id)
)
go

/*==============================================================*/
/* Index: FK_STOCK_MOVE_TRANSFER_FK                           */
/*==============================================================*/




create nonclustered index FK_STOCK_MOVE_TRANSFER_FK on stock_moves (transfer_id ASC)
go

/*==============================================================*/
/* Index: FK_STOCK_NOVES_PRODUCT_ID                                    */
/*==============================================================*/




create nonclustered index FK_STOCK_NOVES_PRODUCT_ID on stock_moves (product_id ASC)
go

/*==============================================================*/
/* Table: transfer_types                                        */
/*==============================================================*/
create table transfer_types (
   transfer_type_id     int                  not null identity(1,1),
   TRANSFER_TYPE_NAME   varchar(100)         not null,
   TRANSFER_TYPE_DESCRIPTION varchar(250)         not null,
   TRANSFER_TYPE_STATE  bit                  not null,
   constraint PK_TRANSFER_TYPES primary key (transfer_type_id)
)
go

/*==============================================================*/
/* Table: transfers                                             */
/*==============================================================*/
create table transfers (
   transfer_id          int                  not null identity(1,1),
   transfer_type_id     int                  null,
   transfer_number      varchar(15)          not null,
   transfer_date        datetime             not null,
   transfer_created     datetime             not null,
   transfer_invoice_number varchar(50)          not null,
   constraint PK_TRANSFERS primary key (transfer_id)
)
go

/*==============================================================*/
/* Index: FK_TRANSFER_TRANSFER_TYPE_FK                        */
/*==============================================================*/




create nonclustered index FK_TRANSFER_TRANSFER_TYPE_FK on transfers (transfer_type_id ASC)
go

/*==============================================================*/
/* Table: users                                                 */
/*==============================================================*/
create table users (
   user_id              int                  not null identity(1,1),
   rol_id               int                  null,
   user_name            varchar(255)         not null,
   user_email           varchar(255)         not null,
   user_state           bit                  not null,
   user_password        varchar(255)         not null,
   constraint PK_USERS primary key (user_id)
)
go

/*==============================================================*/
/* Index: FK_USER_ROL_FK                                      */
/*==============================================================*/




create nonclustered index FK_USER_ROL_FK on users (rol_id ASC)
go

alter table credit
   add constraint FK_CREDIT_FK_CREDIT_CUSTOMER foreign key (customer_id)
      references customer (customer_id)
go

alter table credit
   add constraint FK_CREDIT_FK_USERS_USERS foreign key (user_id)
      references users (user_id)
go

alter table credits_details
   add constraint FK_CREDITS_FK_CREDIT_CREDIT foreign key (credit_id)
      references credit (credit_id)
go

alter table credits_details
   add constraint FK_CREDITS_FK_CREDIT_PRODUCTS foreign key (product_id)
      references products (product_id)
go

alter table products
   add constraint FK_PRODUCTS_FK_PRODU_CATEGORI foreign key (category_id)
      references categories (category_id)
go

alter table stock_adjusts
   add constraint FK_STOCK_AD_FK_STOCK_PRODUCTS foreign key (product_id)
      references products (product_id)
go

alter table stock_moves
   add constraint FK_STOCK_MO_RELATIONS_PRODUCTS foreign key (product_id)
      references products (product_id)
go

alter table stock_moves
   add constraint FK_STOCK_MO_FK_STOCK_TRANSFER foreign key (transfer_id)
      references transfers (transfer_id)
go

alter table transfers
   add constraint FK_TRANSFER_FK_TRANS_TRANSFER foreign key (transfer_type_id)
      references transfer_types (transfer_type_id)
go

alter table users
   add constraint FK_USERS_FK_USER_ROLES foreign key (rol_id)
      references roles (rol_id)
go

