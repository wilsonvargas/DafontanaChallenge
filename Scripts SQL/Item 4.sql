SELECT TOP(1) Local.Nombre AS 'Local', SUM (TotalLinea) as 'VentaTotal'
FROM VentaDetalle
INNER JOIN Venta ON VentaDetalle.ID_Venta = Venta.ID_Venta
INNER JOIN Local ON Venta.ID_Local = Local.ID_Local
WHERE DATEDIFF(DAY, Fecha, GETDATE()) BETWEEN 1 AND 30
GROUP BY Venta.ID_Local, Local.Nombre
ORDER BY VentaTotal DESC