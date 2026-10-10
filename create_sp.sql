-- =========================================================================
-- Ho ten sinh vien: Nguyen Ngoc Minh Thu
-- Ma sinh vien: 2124110080
-- Mo ta: Thu tuc luu tru thong ke tong hop doanh thu theo thu ngan
-- =========================================================================

IF OBJECT_ID('sp_GetRevenueByCashier', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByCashier;
GO

CREATE PROCEDURE sp_GetRevenueByCashier
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END
GO

-- =========================================================================
-- BAI TAP 3.1: Bao cao Doanh thu theo Khoang ngay (Co tham so)
-- =========================================================================
IF OBJECT_ID('sp_GetRevenueByDateRange', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByDateRange;
GO

CREATE PROCEDURE sp_GetRevenueByDateRange
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue
    FROM Orders
    WHERE CreatedDate >= @FromDate AND CreatedDate <= @ToDate
    GROUP BY CashierUsername;
END
GO

-- =========================================================================
-- BAI TAP 3.2: Top 5 San pham Ban chay nhat
-- =========================================================================
IF OBJECT_ID('sp_GetTop5SellingProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTop5SellingProducts;
GO

CREATE PROCEDURE sp_GetTop5SellingProducts
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 5
        p.ProductName,
        SUM(od.Quantity) AS TotalSold
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductId = p.ProductId
    GROUP BY p.ProductId, p.ProductName
    ORDER BY TotalSold DESC;
END
GO
