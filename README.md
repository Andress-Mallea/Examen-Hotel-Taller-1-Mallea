# 🏨 Luxury Resort - Sistema de Gestión Hotelera (MVP)

> **Prototipo académico de una semana** > **Materia:** Taller de Diseño de Software 1  
> **Modalidad:** Individual  

---

## 📝 1. Contexto y Necesidad
Este proyecto nace de la necesidad de un hotel pequeño de sistematizar su operación básica. Actualmente, el manejo manual de huéspedes y reservas dificulta la atención y el control de disponibilidad. 

Esta solución permite registrar huéspedes, gestionar reservas sobre habitaciones precargadas, consultar ocupación y controlar el flujo de **Check-in/Check-out** de manera organizada.

## 🎯 2. Objetivo
Desarrollar un prototipo funcional bajo la arquitectura **MVC (Modelo-Vista-Controlador)**, aplicando reglas de negocio reales y patrones de diseño para demostrar habilidades en análisis, diseño y desarrollo de software.

---

## 🚀 3. Alcance Técnico
### **Capas del Proyecto**
* **Presentación:** Interfaz de usuario dinámica (VanillaJS / CSS Moderno).
* **Control:** Gestión de peticiones y flujo de datos.
* **Servicios:** Lógica de negocio y validaciones.
* **Repositorio:** Acceso a datos y persistencia.
* **Modelos:** Estructuras de datos base.

### **Patrones de Diseño Implementados**
* **Repository & Service:** Para la separación de responsabilidades.
* **Factory / Strategy:** Aplicado específicamente en la **HU-05** para la gestión de variaciones de habitaciones.

---

## 📋 4. Historias de Usuario (Funcionalidades)

| ID | Historia | Descripción |
| :--- | :--- | :--- |
| **HU-01** | **Registrar Huésped** | Registro de datos básicos con validación de duplicados por documento. |
| **HU-02** | **Crear Reserva** | Asociación de huésped y habitación verificando disponibilidad y capacidad. |
| **HU-03** | **Consultar Reservas** | Listado cronológico de la agenda de hospedajes activa y futura. |
| **HU-04** | **Registrar Check-in** | Marcado de ingreso del huésped y cambio de estado de la reserva. |
| **HU-05** | **Gestionar Variación** | (Patrón de Diseño) Asignación automática de características según tipo de habitación (Suite, Simple, etc.). |
| **HU-06** | **Contactos de Servicio** | Visualización de áreas de apoyo (Recepción, Mantenimiento, etc.). |
| **HU-10** | **Consulta de Huésped** | Ficha técnica detallada con información de contacto y documento. |

---

## 🛠️ 5. Reglas de Negocio y Validaciones
* **Validación de Fechas:** La fecha de salida debe ser estrictamente posterior a la de ingreso.
* **Control de Solapamiento:** No se permiten dos reservas en la misma habitación en el mismo rango de fechas.
* **Capacidad Máxima:** El sistema rechaza reservas si la cantidad de personas supera la capacidad de la variación elegida.
* **Estado de Reserva:** Control de flujo para impedir Check-in en reservas canceladas o ya procesadas.

---

## 🗄️ 6. Datos Precargados
Para este MVP, se utilizan datos maestros ya existentes en la base de datos (no administrables por el usuario):
* Capacidades y tipos de habitaciones.
* Contactos de servicios del hotel.

---

## 🚫 7. Fuera de Alcance (Próximas Versiones)
* Módulos de facturación y pagos en línea.
* Gestión de temporadas y tarifas dinámicas.
* Reportes complejos e integraciones externas.
* Sistema de autorización y roles de usuario.

---
**Desarrollado por:** Andres Matias Mallea Acebey  
**Institución:** Universidad Católica Boliviana "San Pablo"
