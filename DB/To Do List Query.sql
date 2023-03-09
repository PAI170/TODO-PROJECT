sp_rename 'Tasks', 'Tareas';

sp_rename 'tareas_completas', 'Tareas_Completadas';

sp_rename 'Categoria', 'Categorias';

sp_rename 'Tareas.id', 'CategoriasID', 'COLUMN';

ALTER TABLE Tareas_Completadas ADD CategoriasID INT NOT NULL;

ALTER TABLE Categorias DROP COLUMN Nombre;

ALTER TABLE Categorias ADD CategoriasID INT IDENTITY (1,1);

ALTER TABLE Categorias ADD Nombre VARCHAR(20);

ALTER TABLE Tareas DROP COLUMN PrioridadTarea;

ALTER TABLE Tareas DROP CONSTRAINT PK__Tasks__3213E83F98BE8AEE;

ALTER TABLE Tareas DROP COLUMN CategoriasID;

EXEC sp_helpindex 'Tareas';

ALTER TABLE Tareas ADD PRIMARY KEY (Descripcion)

ALTER TABLE Tareas_Completadas ADD CONSTRAINT Descripcion_FK FOREIGN KEY (Descripcion) REFERENCES Tareas (Descripcion);

ALTER TABLE Tareas_Completadas ALTER COLUMN CategoriasID INT ;