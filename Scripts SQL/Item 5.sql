SELECT TOP(1)
Marca.Nombre AS 'Marca', 
ROUND(((SUM(VentaDetalle.TotalLinea) - (SUM(Producto.Costo_Unitario * VentaDetalle.Cantidad))) / CAST(SUM(VentaDetalle.TotalLinea) AS FLOAT)) * 100, 2) AS 'Margen'
FROM VentaDetalle
INNER JOIN Venta ON VentaDetalle.ID_Venta = Venta.ID_Venta
INNER JOIN Producto ON VentaDetalle.ID_Producto = Producto.ID_Producto
INNER JOIN Marca ON Producto.ID_Marca = Marca.ID_Marca
WHERE DATEDIFF(DAY, Venta.Fecha, GETDATE()) BETWEEN 1 AND 30
GROUP BY Marca.Nombre
ORDER BY Margen DESC