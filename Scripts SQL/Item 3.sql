SELECT TOP (1) Producto.Nombre AS 'Producto', SUM (TotalLinea) as 'VentaTotal'
FROM VentaDetalle
INNER JOIN Venta ON VentaDetalle.ID_Venta = Venta.ID_Venta
INNER JOIN Producto ON VentaDetalle.ID_Producto = Producto.ID_Producto
WHERE DATEDIFF(DAY, Fecha, GETDATE()) BETWEEN 1 AND 30
GROUP BY Producto.ID_Producto, Producto.Nombre
ORDER BY VentaTotal DESC