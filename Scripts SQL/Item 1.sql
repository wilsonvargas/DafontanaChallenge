SELECT SUM (TotalLinea) as 'Monto', COUNT(Venta.ID_Venta) AS 'Cantidad' 
FROM VentaDetalle
INNER JOIN Venta ON VentaDetalle.ID_Venta = Venta.ID_Venta
INNER JOIN Producto ON VentaDetalle.ID_Producto = Producto.ID_Producto
WHERE DATEDIFF(DAY, Fecha, GETDATE()) BETWEEN 1 AND 30