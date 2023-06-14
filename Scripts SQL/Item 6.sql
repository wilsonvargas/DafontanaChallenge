SELECT
    NombreLocal,
    NombreProducto,
    Cantidad
FROM (
    SELECT
        Local.Nombre AS NombreLocal,
        Producto.Nombre AS NombreProducto,
        SUM(VentaDetalle.Cantidad) AS Cantidad,
        ROW_NUMBER() OVER (PARTITION BY Local.Nombre ORDER BY SUM(VentaDetalle.Cantidad) DESC) AS RowNum
    FROM VentaDetalle
    INNER JOIN Venta ON VentaDetalle.ID_Venta = Venta.ID_Venta
    INNER JOIN Local ON Venta.ID_Local = Local.ID_Local
    INNER JOIN Producto ON VentaDetalle.ID_Producto = Producto.ID_Producto
    WHERE DATEDIFF(DAY, Venta.Fecha, GETDATE()) BETWEEN 1 AND 30
    GROUP BY Local.Nombre, Producto.Nombre
) AS SalesData
WHERE RowNum = 1
ORDER BY Cantidad DESC