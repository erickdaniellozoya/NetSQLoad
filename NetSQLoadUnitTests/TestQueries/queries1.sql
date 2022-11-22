-- query1
SELECT * FROM Employees;

-- query2
SELECT * FROM Employees WHERE id = {0};

-- query3
SELECT * FROM Employees WHERE id = {0};
UPDATE Employees SET active = 0 WHERE id = {0} AND active = {1};