# Sistema de Gestión de Nóminas 📊

## Índice
1. [Introducción](#introducción)
   - [Propósito](#propósito)
   - [Alcance](#alcance)
2. [Descripción General](#descripción-general)
   - [Perspectiva del Producto](#perspectiva-del-producto)
   - [Suposiciones y Dependencias](#suposiciones-y-dependencias)
3. [Requisitos Funcionales](#requisitos-funcionales)
   - [Gestión de Empleados](#gestión-de-empleados)
   - [Cálculo de Pago](#cálculo-de-pago)
   - [Generación de Reportes](#generación-de-reportes)
4. [Requisitos No Funcionales](#requisitos-no-funcionales)
   - [Usabilidad](#usabilidad)
   - [Escalabilidad](#escalabilidad)
   - [Mantenibilidad](#mantenibilidad)
   - [Rendimiento](#rendimiento)

## Introducción

### Propósito
El propósito de este sistema es proporcionar una aplicación web robusta para la gestión de pagos de empleados. La aplicación permite calcular los pagos semanales, gestionar datos de empleados y generar reportes detallados.

### Alcance
El sistema se centra en el cálculo de pagos semanales para diferentes categorías de empleados:
- Asalariados
- Por horas
- Por comisión
- Asalariados por comisión

## Descripción General

### Perspectiva del Producto
Esta aplicación web está diseñada para ser utilizada por el departamento de recursos humanos, ofreciendo:
- Interfaz intuitiva para gestión de datos
- Cálculos automáticos de pagos
- Generación de reportes detallados

### Suposiciones y Dependencias
- Desarrollo en .NET 8 y C#
- Almacenamiento de datos en memoria

## Requisitos Funcionales

### Gestión de Empleados
**RF-1:** Captura de datos según tipo de empleado:

1. **Empleado Asalariado:**
   - Primer nombre
   - Apellido paterno
   - Número seguro social
   - Salario semanal

2. **Empleado por Horas:**
   - Apellido paterno
   - Número seguro social
   - Sueldo por hora
   - Horas trabajadas

3. **Empleado por Comisión:**
   - Primer nombre
   - Apellido paterno
   - Número seguro social
   - Ventas brutas
   - Tarifa comisión

4. **Empleado Asalariado por Comisión:**
   - Primer nombre
   - Apellido paterno
   - Número seguro social
   - Ventas brutas
   - Tarifa comisión
   - Salario base

### Cálculo de Pago
**RF-2:** Cálculos automáticos según tipo de empleado:

1. **Empleado Asalariado:**
   ```
   Pago semanal = salarioSemanal
   ```

2. **Empleado por Horas:**
   ```
   Si horasTrabajadas ≤ 40:
   Pago = sueldoPorHora × horasTrabajadas

   Si horasTrabajadas > 40:
   Pago = (sueldoPorHora × 40) + (sueldoPorHora × 1.5 × (horasTrabajadas - 40))
   ```

3. **Empleado por Comisión:**
   ```
   Pago semanal = ventasBrutas × tarifaComision
   ```

4. **Empleado Asalariado por Comisión:**
   ```
   Pago semanal = (ventasBrutas × tarifaComision) + salarioBase + (salarioBase × 0.10)
   ```

**RF-3:** Actualización de información y recálculo de pagos.

### Generación de Reportes
**RF-4:** Generación de reportes semanales detallados por empleado.

## Requisitos No Funcionales

### Usabilidad
**RNF-1:** Interfaz intuitiva y accesible para usuarios no técnicos.

### Escalabilidad
**RNF-2:** Arquitectura extensible que permite:
- Incorporación de nuevos tipos de empleados
- Adición de cálculos adicionales
- Modificaciones sin afectar el código existente

### Mantenibilidad
**RNF-3:** Diseño modular que facilita:
- Adición de nuevas funcionalidades
- Modificación de módulos existentes
- Mantenimiento y adaptación a cambios

### Rendimiento
**RNF-4:** Procesamiento eficiente:
- Capacidad para manejar hasta 1,000 empleados
- Tiempo de procesamiento < 2 segundos