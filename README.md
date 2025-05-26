# Especificación de Requisitos de Software (SRS)

## 1. Introducción

### 1.1 Propósito

El propósito de este documento es definir los requisitos funcionales y no funcionales para una **aplicación web de gestión de pagos de empleados**. La aplicación permitirá a una compañía calcular los pagos semanales de sus empleados, capturar y almacenar datos de los empleados, y generar reportes.

### 1.2 Alcance

Este sistema se enfocará en el **cálculo de pagos semanales** para diferentes tipos de empleados: asalariados, por horas, por comisión y asalariados por comisión. La aplicación también incluirá la captura de datos de los empleados, el cálculo de pago automático y la generación de reportes.

---

## 2. Descripción General

### 2.1 Perspectiva del Producto

La aplicación web será utilizada por el departamento de recursos humanos para calcular y gestionar los pagos semanales de los empleados. Proporcionará una interfaz intuitiva para capturar datos, calcular pagos basados en el tipo de contrato del empleado y generar reportes detallados.

### 2.2 Suposiciones y Dependencias

- La aplicación será desarrollada usando **.NET 8 y C#**.
- Los datos de los empleados se almacenarán en una **colección en memoria**.

---

## 3. Requisitos Funcionales

### 3.1 Gestión de Empleados

**RF-1:** El sistema debe permitir la captura de los datos de los empleados según su tipo:

- **Empleado Asalariado:**
  - Captura: `primerNombre`, `apellidoPaterno`, `numeroSeguroSocial`, `salarioSemanal`
- **Empleado por Horas:**
  - Captura: `apellidoPaterno`, `numeroSeguroSocial`, `sueldoPorHora`, `horasTrabajadas`
- **Empleado por Comisión:**
  - Captura: `primerNombre`, `apellidoPaterno`, `numeroSeguroSocial`, `ventasBrutas`, `tarifaComision`
- **Empleado Asalariado por Comisión:**
  - Captura: `primerNombre`, `apellidoPaterno`, `numeroSeguroSocial`, `ventasBrutas`, `tarifaComision`, `salarioBase`

### 3.2 Cálculo de Pago

**RF-2:** El sistema debe calcular automáticamente el pago semanal según el tipo de empleado:

- **Empleado Asalariado:**  
  `Pago semanal = salarioSemanal`
- **Empleado por Horas:**
  - Si `horasTrabajadas ≤ 40`, entonces el pago = `sueldoPorHora × horasTrabajadas`
  - Si `horasTrabajadas > 40`, entonces el pago = `(sueldoPorHora × 40) + (sueldoPorHora × 1.5 × (horasTrabajadas - 40))`
- **Empleado por Comisión:**  
  `Pago semanal = ventasBrutas × tarifaComision`
- **Empleado Asalariado por Comisión:**  
  `Pago semanal = (ventasBrutas × tarifaComision) + salarioBase + (salarioBase × 0.10)`

**RF-3:** El sistema debe permitir actualizar la información de los empleados para recalcular el pago si es necesario.

### 3.3 Generación de Reportes

**RF-4:** El sistema debe generar un **reporte semanal** con el pago de cada empleado, detallando los cálculos según el tipo de contrato.

---

## 4. Requisitos No Funcionales

### 4.1 Usabilidad

**RNF-1:** La interfaz debe ser **intuitiva y fácil de navegar** para usuarios no técnicos.

### 4.2 Escalabilidad

**RNF-2:** La arquitectura del sistema debe ser **escalable**, permitiendo la inclusión de nuevos tipos de empleados y cálculos adicionales sin modificar el código existente.

### 4.3 Mantenibilidad

**RNF-3:** El sistema debe estar diseñado de manera **modular** para facilitar la adición o modificación de funcionalidades sin afectar otros módulos. Además, debe ser fácil de mantener y adaptable a cambios.

### 4.4 Rendimiento

**RNF-4:** El sistema debe procesar los cálculos de pago para **hasta 1,000 empleados en menos de 2 segundos**.

---
