# EntityTest3
<b>PRACTICA INICIAL DE ENTITY FRAMEWORK 6 CON BASE DE DATOS ORACLE</b>

<b>TABLA ESTUDIANTES</b>


CREATE TABLE "DEV_001"."ESTUDIANTE" 
   (	"ID" NUMBER, 
	"NOMBRE" VARCHAR2(100 BYTE), 
	"APELLIDO" VARCHAR2(100 BYTE), 
	"EMAIL" VARCHAR2(100 BYTE), 
	"EDAD" NUMBER, 
	"FECHA_NACIMIENTO" DATE DEFAULT SYSDATE, 
	"SEXO" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "APEX_5341200684711777" ;
REM INSERTING into DEV_001.ESTUDIANTE
SET DEFINE OFF;
Insert into DEV_001.ESTUDIANTE (ID,NOMBRE,APELLIDO,EMAIL,EDAD,FECHA_NACIMIENTO,SEXO) values (1,'OMAR','MUNGUIA RIVERA','omar@gmail.com',28,to_date('01/03/98','DD/MM/RR'),1);
Insert into DEV_001.ESTUDIANTE (ID,NOMBRE,APELLIDO,EMAIL,EDAD,FECHA_NACIMIENTO,SEXO) values (23,'EFRA','PERIAÑEZ GARCIA','EFRA@GMAIL.COM',28,to_date('01/02/88','DD/MM/RR'),1);

/*  DDL for Index ESTUDIANTE_PK*/


  CREATE UNIQUE INDEX "DEV_001"."ESTUDIANTE_PK" ON "DEV_001"."ESTUDIANTE" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "APEX_5341200684711777" ;
  
/*
  Constraints for Table ESTUDIANTE
*/

  ALTER TABLE "DEV_001"."ESTUDIANTE" ADD CONSTRAINT "ESTUDIANTE_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "APEX_5341200684711777"  ENABLE;
  ALTER TABLE "DEV_001"."ESTUDIANTE" MODIFY ("SEXO" NOT NULL ENABLE);
  ALTER TABLE "DEV_001"."ESTUDIANTE" MODIFY ("EDAD" NOT NULL ENABLE);
  ALTER TABLE "DEV_001"."ESTUDIANTE" MODIFY ("APELLIDO" NOT NULL ENABLE);
  ALTER TABLE "DEV_001"."ESTUDIANTE" MODIFY ("NOMBRE" NOT NULL ENABLE);
  ALTER TABLE "DEV_001"."ESTUDIANTE" MODIFY ("ID" NOT NULL ENABLE);
  
/*
  DDL for Trigger BI_ESTUDIANTE
*/

  CREATE OR REPLACE TRIGGER "DEV_001"."BI_ESTUDIANTE" 
  before insert on "ESTUDIANTE"               
  for each row  
begin   
  if :NEW."ID" is null then 
    select "ESTUDIANTE_SEQ".nextval into :NEW."ID" from sys.dual; 
  end if; 
end; 

/
ALTER TRIGGER "DEV_001"."BI_ESTUDIANTE" ENABLE;

/*  DDL for Trigger ESTUDIANTE_SEQ_INSERT_TRIGGER */

  CREATE OR REPLACE TRIGGER "DEV_001"."ESTUDIANTE_SEQ_INSERT_TRIGGER" 
BEFORE INSERT ON ESTUDIANTE 
FOR EACH ROW
 WHEN (new.id IS NULL OR new.id = 0) BEGIN
  SELECT ESTUDIANTE_SEQ.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
ALTER TRIGGER "DEV_001"."ESTUDIANTE_SEQ_INSERT_TRIGGER" ENABLE;
