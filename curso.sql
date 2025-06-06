-- Cursos para Licenciatura en Contador Público (Id_Carrera = 1)
INSERT INTO Curso (Id_Carrera, Id_Materia, Id_Docente, Capacidad, Creditos, Periodo) VALUES
(1, 1, 7, 30, 5, '2023-1'), (1, 1, 8, 25, 5, '2023-2'), -- Contabilidad Financiera
(1, 2, 9, 30, 5, '2023-1'), (1, 2, 10, 25, 5, '2023-2'), -- Auditoría Fiscal
(1, 3, 11, 30, 5, '2023-1'), (1, 3, 12, 25, 5, '2023-2'), -- Costos y Presupuestos
(1, 4, 13, 30, 5, '2023-1'), (1, 4, 14, 25, 5, '2023-2'), -- Derecho Fiscal
(1, 5, 15, 30, 5, '2023-1'), (1, 5, 16, 25, 5, '2023-2'), -- Contabilidad de Sociedades
(1, 6, 17, 30, 4, '2023-1'), (1, 6, 18, 25, 4, '2023-2'), -- Ética Profesional del Contador
(1, 7, 19, 30, 5, '2023-1'), (1, 7, 20, 25, 5, '2023-2'), -- Normas Internacionales
(1, 8, 21, 30, 5, '2023-1'), (1, 8, 22, 25, 5, '2023-2'), -- Análisis de Estados Financieros
(1, 9, 23, 30, 5, '2023-1'), (1, 9, 24, 25, 5, '2023-2'), -- Contabilidad Gubernamental
(1, 10, 25, 30, 5, '2023-1'), (1, 10, 26, 25, 5, '2023-2'), -- Sistemas de Información Contable
(1, 61, 27, 40, 5, '2023-1'), (1, 61, 28, 35, 5, '2023-2'), -- Matemáticas Básicas
(1, 62, 29, 40, 5, '2023-1'), (1, 62, 30, 35, 5, '2023-2'), -- Cálculo Diferencial
(1, 63, 31, 40, 5, '2023-1'), (1, 63, 32, 35, 5, '2023-2'), -- Estadística
(1, 65, 33, 35, 4, '2023-1'), (1, 65, 34, 30, 4, '2023-2'), -- Comunicación Oral
(1, 70, 35, 35, 4, '2023-1'), (1, 70, 36, 30, 4, '2023-2'); -- Informática Aplicada

-- Cursos para Ingeniería en Sistemas Computacionales (Id_Carrera = 2)
INSERT INTO Curso (Id_Carrera, Id_Materia, Id_Docente, Capacidad, Creditos, Periodo) VALUES
(2, 11, 7, 25, 5, '2023-1'), (2, 11, 8, 20, 5, '2023-2'), -- Programación Avanzada
(2, 12, 9, 25, 5, '2023-1'), (2, 12, 10, 20, 5, '2023-2'), -- Arquitectura de Computadoras
(2, 13, 11, 25, 5, '2023-1'), (2, 13, 12, 20, 5, '2023-2'), -- Sistemas Operativos
(2, 14, 13, 25, 5, '2023-1'), (2, 14, 14, 20, 5, '2023-2'), -- Redes de Computadoras
(2, 15, 15, 25, 5, '2023-1'), (2, 15, 16, 20, 5, '2023-2'), -- Inteligencia Artificial
(2, 16, 17, 25, 5, '2023-1'), (2, 16, 18, 20, 5, '2023-2'), -- Desarrollo de Software
(2, 17, 19, 25, 5, '2023-1'), (2, 17, 20, 20, 5, '2023-2'), -- Seguridad Informática
(2, 18, 21, 25, 5, '2023-1'), (2, 18, 22, 20, 5, '2023-2'), -- Computación en la Nube
(2, 19, 23, 25, 5, '2023-1'), (2, 19, 24, 20, 5, '2023-2'), -- Internet de las Cosas
(2, 20, 25, 25, 5, '2023-1'), (2, 20, 26, 20, 5, '2023-2'), -- Realidad Virtual
(2, 61, 27, 35, 5, '2023-1'), (2, 61, 28, 30, 5, '2023-2'), -- Matemáticas Básicas
(2, 62, 29, 35, 5, '2023-1'), (2, 62, 30, 30, 5, '2023-2'), -- Cálculo Diferencial
(2, 63, 31, 35, 5, '2023-1'), (2, 63, 32, 30, 5, '2023-2'), -- Estadística
(2, 65, 33, 30, 4, '2023-1'), (2, 65, 34, 25, 4, '2023-2'), -- Comunicación Oral
(2, 70, 35, 30, 4, '2023-1'), (2, 70, 36, 25, 4, '2023-2'); -- Informática Aplicada

-- Cursos para Ingeniería en Electromecánica (Id_Carrera = 3)
INSERT INTO Curso (Id_Carrera, Id_Materia, Id_Docente, Capacidad, Creditos, Periodo) VALUES
(3, 21, 7, 25, 5, '2023-1'), (3, 21, 8, 20, 5, '2023-2'), -- Circuitos Eléctricos
(3, 22, 9, 25, 5, '2023-1'), (3, 22, 10, 20, 5, '2023-2'), -- Máquinas Eléctricas
(3, 23, 11, 25, 5, '2023-1'), (3, 23, 12, 20, 5, '2023-2'), -- Controladores Lógicos
(3, 24, 13, 25, 5, '2023-1'), (3, 24, 14, 20, 5, '2023-2'), -- Termodinámica Aplicada
(3, 25, 15, 25, 5, '2023-1'), (3, 25, 16, 20, 5, '2023-2'), -- Dibujo Mecánico
(3, 26, 17, 25, 5, '2023-1'), (3, 26, 18, 20, 5, '2023-2'), -- Mecánica de Materiales
(3, 27, 19, 25, 5, '2023-1'), (3, 27, 20, 20, 5, '2023-2'), -- Automatización Industrial
(3, 28, 21, 25, 5, '2023-1'), (3, 28, 22, 20, 5, '2023-2'), -- Instrumentación Industrial
(3, 29, 23, 25, 5, '2023-1'), (3, 29, 24, 20, 5, '2023-2'), -- Energías Renovables
(3, 30, 25, 25, 5, '2023-1'), (3, 30, 26, 20, 5, '2023-2'), -- Mantenimiento Industrial
(3, 61, 27, 35, 5, '2023-1'), (3, 61, 28, 30, 5, '2023-2'), -- Matemáticas Básicas
(3, 62, 29, 35, 5, '2023-1'), (3, 62, 30, 30, 5, '2023-2'), -- Cálculo Diferencial
(3, 63, 31, 35, 5, '2023-1'), (3, 63, 32, 30, 5, '2023-2'), -- Estadística
(3, 65, 33, 30, 4, '2023-1'), (3, 65, 34, 25, 4, '2023-2'), -- Comunicación Oral
(3, 70, 35, 30, 4, '2023-1'), (3, 70, 36, 25, 4, '2023-2'); -- Informática Aplicada

-- Cursos para Licenciatura en Administración de Empresas (Id_Carrera = 4)
INSERT INTO Curso (Id_Carrera, Id_Materia, Id_Docente, Capacidad, Creditos, Periodo) VALUES
(4, 31, 7, 30, 5, '2023-1'), (4, 31, 8, 25, 5, '2023-2'), -- Administración Estratégica
(4, 32, 9, 30, 5, '2023-1'), (4, 32, 10, 25, 5, '2023-2'), -- Comportamiento Organizacional
(4, 33, 11, 30, 5, '2023-1'), (4, 33, 12, 25, 5, '2023-2'), -- Gestión de Proyectos
(4, 34, 13, 30, 5, '2023-1'), (4, 34, 14, 25, 5, '2023-2'), -- Marketing Digital
(4, 35, 15, 30, 5, '2023-1'), (4, 35, 16, 25, 5, '2023-2'), -- Logística
(4, 36, 17, 30, 5, '2023-1'), (4, 36, 18, 25, 5, '2023-2'), -- Negocios Internacionales
(4, 37, 19, 30, 5, '2023-1'), (4, 37, 20, 25, 5, '2023-2'), -- Emprendimiento
(4, 38, 21, 30, 5, '2023-1'), (4, 38, 22, 25, 5, '2023-2'), -- Gestión del Talento
(4, 39, 23, 30, 4, '2023-1'), (4, 39, 24, 25, 4, '2023-2'), -- Responsabilidad Social
(4, 40, 25, 30, 5, '2023-1'), (4, 40, 26, 25, 5, '2023-2'), -- Administración de Pymes
(4, 61, 27, 40, 5, '2023-1'), (4, 61, 28, 35, 5, '2023-2'), -- Matemáticas Básicas
(4, 62, 29, 40, 5, '2023-1'), (4, 62, 30, 35, 5, '2023-2'), -- Cálculo Diferencial
(4, 63, 31, 40, 5, '2023-1'), (4, 63, 32, 35, 5, '2023-2'), -- Estadística
(4, 65, 33, 35, 4, '2023-1'), (4, 65, 34, 30, 4, '2023-2'), -- Comunicación Oral
(4, 70, 35, 35, 4, '2023-1'), (4, 70, 36, 30, 4, '2023-2'); -- Informática Aplicada

-- Cursos para Ingeniería en Bioquímica (Id_Carrera = 5)
INSERT INTO Curso (Id_Carrera, Id_Materia, Id_Docente, Capacidad, Creditos, Periodo) VALUES
(5, 41, 7, 20, 5, '2023-1'), (5, 41, 8, 15, 5, '2023-2'), -- Bioquímica Clínica
(5, 42, 9, 20, 5, '2023-1'), (5, 42, 10, 15, 5, '2023-2'), -- Microbiología Industrial
(5, 43, 11, 20, 5, '2023-1'), (5, 43, 12, 15, 5, '2023-2'), -- Biotecnología Molecular
(5, 44, 13, 20, 5, '2023-1'), (5, 44, 14, 15, 5, '2023-2'), -- Química de Alimentos
(5, 45, 15, 20, 5, '2023-1'), (5, 45, 16, 15, 5, '2023-2'), -- Toxicología
(5, 46, 17, 20, 5, '2023-1'), (5, 46, 18, 15, 5, '2023-2'), -- Fermentaciones Industriales
(5, 47, 19, 20, 5, '2023-1'), (5, 47, 20, 15, 5, '2023-2'), -- Análisis Instrumental
(5, 48, 21, 20, 5, '2023-1'), (5, 48, 22, 15, 5, '2023-2'), -- Ingeniería de Bioprocesos
(5, 49, 23, 20, 5, '2023-1'), (5, 49, 24, 15, 5, '2023-2'), -- Control de Calidad
(5, 50, 25, 20, 4, '2023-1'), (5, 50, 26, 15, 4, '2023-2'), -- Normatividad Bioquímica
(5, 61, 27, 30, 5, '2023-1'), (5, 61, 28, 25, 5, '2023-2'), -- Matemáticas Básicas
(5, 62, 29, 30, 5, '2023-1'), (5, 62, 30, 25, 5, '2023-2'), -- Cálculo Diferencial
(5, 63, 31, 30, 5, '2023-1'), (5, 63, 32, 25, 5, '2023-2'), -- Estadística
(5, 65, 33, 25, 4, '2023-1'), (5, 65, 34, 20, 4, '2023-2'), -- Comunicación Oral
(5, 70, 35, 25, 4, '2023-1'), (5, 70, 36, 20, 4, '2023-2'); -- Informática Aplicada

-- Cursos para Ingeniería en Ciencia de Datos (Id_Carrera = 6)
INSERT INTO Curso (Id_Carrera, Id_Materia, Id_Docente, Capacidad, Creditos, Periodo) VALUES
(6, 51, 7, 25, 5, '2023-1'), (6, 51, 8, 20, 5, '2023-2'), -- Minería de Datos
(6, 52, 9, 25, 5, '2023-1'), (6, 52, 10, 20, 5, '2023-2'), -- Aprendizaje Automático
(6, 53, 11, 25, 5, '2023-1'), (6, 53, 12, 20, 5, '2023-2'), -- Visualización de Datos
(6, 54, 13, 25, 5, '2023-1'), (6, 54, 14, 20, 5, '2023-2'), -- Big Data
(6, 55, 15, 25, 5, '2023-1'), (6, 55, 16, 20, 5, '2023-2'), -- Estadística Multivariante
(6, 56, 17, 25, 5, '2023-1'), (6, 56, 18, 20, 5, '2023-2'), -- Procesamiento de Lenguaje Natural
(6, 57, 19, 25, 5, '2023-1'), (6, 57, 20, 20, 5, '2023-2'), -- Modelos Predictivos
(6, 58, 21, 25, 5, '2023-1'), (6, 58, 22, 20, 5, '2023-2'), -- Deep Learning
(6, 59, 23, 25, 5, '2023-1'), (6, 59, 24, 20, 5, '2023-2'), -- Análisis de Series de Tiempo
(6, 60, 25, 25, 4, '2023-1'), (6, 60, 26, 20, 4, '2023-2'), -- Ética en Ciencia de Datos
(6, 61, 27, 35, 5, '2023-1'), (6, 61, 28, 30, 5, '2023-2'), -- Matemáticas Básicas
(6, 62, 29, 35, 5, '2023-1'), (6, 62, 30, 30, 5, '2023-2'), -- Cálculo Diferencial
(6, 63, 31, 35, 5, '2023-1'), (6, 63, 32, 30, 5, '2023-2'), -- Estadística
(6, 65, 33, 30, 4, '2023-1'), (6, 65, 34, 25, 4, '2023-2'), -- Comunicación Oral
(6, 70, 35, 30, 4, '2023-1'), (6, 70, 36, 25, 4, '2023-2'); -- Informática Aplicada