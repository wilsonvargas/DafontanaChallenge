SELECT TOP(1) Venta.Fecha, Venta.Total 
FROM VentaDetalle
INNER JOIN Venta ON VentaDetalle.ID_Venta = Venta.ID_Venta
INNER JOIN Producto ON VentaDetalle.ID_Producto = Producto.ID_Producto
WHERE DATEDIFF(DAY, Fecha, GETDATE()) BETWEEN 1 AND 30
ORDER BY Venta.Total DESC