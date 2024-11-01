---------------------------------------------------------------------
--1. Write a query that displays Full name of an employee who has more 
--than 3 letters in his/her First Name.
---------------------------------------------------------------------

SELECT CONCAT(Fname , ' ' ,Lname) 
FROM Employee
WHERE Fname LIKE '____%'
-- OR
SELECT CONCAT(Fname , ' ' ,Lname) 
FROM Employee
WHERE LEN(Fname) > 3

--------------------------------------------------------------------
--2. Write a query to display the total number of Programming books
--available in the library with alias name ‘NO OF PROGRAMMING
--BOOKS’ 
--------------------------------------------------------------------

SELECT COUNT(*) AS [NO OF PROGRAMMING BOOKS]
FROM Book
WHERE Cat_id = (SELECT Id FROM Category WHERE Cat_name = 'Programming')

--OR

SELECT COUNT(*) AS [NO OF PROGRAMMING BOOKS]
FROM Book INNER JOIN Category
ON Book.Cat_id = Category.Id
WHERE Cat_name = 'Programming'

--------------------------------------------------------------------
--3. Write a query to display the number of books published by
--(HarperCollins) with the alias name 'NO_OF_BOOKS'.
--------------------------------------------------------------------

SELECT COUNT(*) AS [NO_OF_BOOKS]
FROM Book
WHERE Publisher_id = (SELECT Id FROM Publisher WHERE [Name] = 'HarperCollins')

--OR

SELECT COUNT(*) AS [NO_OF_BOOKS]
FROM Book INNER JOIN Publisher
ON Book.Publisher_id = Publisher.Id
WHERE Publisher.Name = 'HarperCollins'

--------------------------------------------------------------------
--4. Write a query to display the User SSN and name, date of borrowing 
--and due date of the User whose due date is before July 2022.
--------------------------------------------------------------------

SELECT SSN , [User_Name] , Borrow_date ,Due_date
FROM Users INNER JOIN Borrowing
ON Users.SSN = Borrowing.User_ssn
WHERE Due_date < '2022-07-1'

--------------------------------------------------------------------
--5. Write a query to display book title, author name and display in 
--the following format,
--' [Book Title] is written by [Author Name].
--------------------------------------------------------------------

--If a book has multiple authors, this query will return one row per author
SELECT CONCAT(Title ,' is written by ',[Name]) 
FROM Book INNER JOIN Book_Author
ON Book.Id = Book_Author.Book_id
INNER JOIN Author
ON Book_Author.Author_id = Author.Id
ORDER BY Title

--this query combine multiple authors for a single book into one row
SELECT CONCAT(TITLE ,' is written by ',STRING_AGG(Name, ', '))
FROM Book INNER JOIN Book_Author
ON Book.Id = Book_Author.Book_id
INNER JOIN Author
ON Book_Author.Author_id = Author.Id
GROUP BY Title
ORDER BY Title
--Note : here the output is identical as all inserted books has only one author

--------------------------------------------------------------------
--6. Write a query to display the name of users who have letter 'A' in 
--their names.
--------------------------------------------------------------------

SELECT [User_Name]
FROM Users
WHERE [User_Name] LIKE '%A%'

--------------------------------------------------------------------
--7. Write a query that display user SSN who makes the most borrowing
--------------------------------------------------------------------

-- IF [who makes the most borrowing] means the number of borrowing operations
SELECT TOP(1) WITH TIES User_ssn
FROM Borrowing
GROUP BY User_ssn 
ORDER BY COUNT(*) DESC

 --IF [who makes the most borrowing] means the max amount
SELECT User_ssn
FROM (SELECT DENSE_RANK() OVER (ORDER BY Amount DESC) DR,* FROM Borrowing) AS TEMP
WHERE DR =1

--------------------------------------------------------------------
--8. Write a query that displays the total amount of money that each 
--user paid for borrowing books.
--------------------------------------------------------------------

SELECT User_ssn , SUM(Amount) [money paid]
FROM Borrowing
GROUP BY User_ssn
ORDER BY SUM(Amount) DESC

--------------------------------------------------------------------
--9. write a query that displays the category which has the book that 
--has the minimum amount of money for borrowing.
--------------------------------------------------------------------

SELECT TOP(1) WITH TIES Cat_name 
FROM Borrowing INNER JOIN Book
ON Borrowing.Book_id = Book.Id
INNER JOIN Category
ON Book.Cat_id = Category.Id
ORDER BY Amount 

--------------------------------------------------------------------
--10.write a query that displays the email of an employee if it's 
--not found, display address if it's not found, display date of birthday.
--------------------------------------------------------------------

SELECT COALESCE(Email , [Address] ,CONVERT(VARCHAR(20),DOB))
FROM Employee

--------------------------------------------------------------------
--11. Write a query to list the category and number of books in each 
--category with the alias name 'Count Of Books'.
--------------------------------------------------------------------

SELECT Cat_name , COUNT(*) AS [Count Of Books]
FROM Book INNER JOIN Category
ON Book.Cat_id = Category.Id
GROUP BY Cat_name

--------------------------------------------------------------------
--12. Write a query that display books id which is not found in floor 
--num = 1 and shelf-code = A1.
--------------------------------------------------------------------

SELECT Id
FROM Book INNER JOIN Shelf
ON Book.Shelf_code = Shelf.Code
WHERE Floor_num != 1 AND Shelf_code != 'A1'

--------------------------------------------------------------------
--13.Write a query that displays the floor number , Number of Blocks 
--and number of employees working on that floor.
--------------------------------------------------------------------

SELECT Number , Num_blocks , COUNT(Employee.Floor_no) AS [Number of employees]
FROM [Floor] LEFT JOIN Employee
ON [Floor].Number = Employee.Floor_no
GROUP BY Number , Num_blocks 

--------------------------------------------------------------------
--14.Display Book Title and User Name to designate Borrowing that 
--occurred within the period ‘3/1/2022’ and ‘10/1/2022’.
--------------------------------------------------------------------

SELECT Title , [User_Name]  , Borrow_date
FROM Book INNER JOIN Borrowing
ON Book.Id = Borrowing.Book_id
INNER JOIN Users
ON Borrowing.User_ssn = Users.SSN 
WHERE Borrow_date BETWEEN '3/1/2022' AND '10/1/2022'

--------------------------------------------------------------------
--15.Display Employee Full Name and Name Of his/her Supervisor as
--Supervisor Name.
--------------------------------------------------------------------

SELECT CONCAT(Emp.Fname ,' ',Emp.Lname) AS [Employee name]  
       ,CONCAT(Supervisor.Fname ,' ',Supervisor.Lname) AS [Supervisor name] 
FROM Employee AS Emp LEFT JOIN Employee AS Supervisor
ON Emp.Super_id = Supervisor.Id

--------------------------------------------------------------------
--16.Select Employee name and his/her salary but if there is no salary 
--display Employee bonus.
--------------------------------------------------------------------

SELECT Fname , ISNULL(Salary,Bouns) AS [Salary | Bonus]
FROM Employee

------------------------------------------------
--17.Display max and min salary for Employees 
------------------------------------------------

SELECT MAX(Salary) AS [Max Salary] , MIN(Salary) AS [Min Salary]
FROM Employee

------------------------------------------------
--18.Write a function that take Number and display 
--if it is even or odd 
------------------------------------------------
CREATE FUNCTION CheckEvenOrOdd (@number INT)
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @result VARCHAR(5)
	IF @number % 2 = 0
		SET @result = 'EVEN'
	ELSE
		SET @result = 'ODD'
	RETURN @result
END

SELECT dbo.CheckEvenOrOdd(10)
SELECT dbo.CheckEvenOrOdd(11)

------------------------------------------------
--19.write a function that take category name and 
--display Title of books in that category 
------------------------------------------------

CREATE FUNCTION GetTitles (@category VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
	SELECT Title 
	FROM Book INNER JOIN Category
	ON Book.Cat_id = Category.Id
	WHERE Cat_name = @category
)

SELECT * FROM GetTitles ('programming ')
SELECT * FROM GetTitles ('Medical')

-----------------------------------------------------------
 --20. write a function that takes the phone of the user and 
 --displays Book Title , user-name,  amount of money and due-date.
-----------------------------------------------------------
CREATE FUNCTION GetData(@email VARCHAR(30))
RETURNS TABLE
AS 
RETURN
(
 SELECT Title , [User_Name] , Amount ,Due_date
 FROM Users INNER JOIN Borrowing
 ON Users.SSN = Borrowing.User_ssn
 INNER JOIN Book
 ON Borrowing.Book_id = Book.Id
 WHERE User_Email = @email
)

SELECT * FROM GetData('Amr@gmail.com')
SELECT * FROM GetData('Ash@gmail.com')

-----------------------------------------------------------
 --21.Write a function that take user name and check if it's duplicated
 --return Message in the following format ([User Name] is Repeated
 --[Count] times) if it's not duplicated display msg with this format [user
 --name] is not duplicated,if it's not Found Return [User Name] is Not
 --Found 
----------------------------------------------------------
CREATE FUNCTION CheckDuplicates(@UserName NVARCHAR(30))
RETURNS NVARCHAR(40)
AS
BEGIN
    DECLARE @Msg NVARCHAR(200)  
    DECLARE @Count INT

    SELECT @Count = COUNT(*)
    FROM Users
    WHERE [User_Name] = @UserName

    SET @Msg = 
        CASE 
            WHEN @Count > 1 
            THEN CONCAT(@UserName, ' is Repeated ', @Count, ' times')
            WHEN @Count = 1
            THEN CONCAT(@UserName, ' is not duplicated')
            ELSE CONCAT(@UserName, ' is Not Found')
        END

    RETURN @Msg
END

SELECT dbo.CheckDuplicates('Amr Ahmed')
SELECT dbo.CheckDuplicates('Roro Ahmed')
SELECT dbo.CheckDuplicates('Ahmed Khalid')

----------------------------------------------------------
 --22.Create a scalar function that takes date and Format to
 -- return Date With That Format.
----------------------------------------------------------
CREATE FUNCTION FormatDate (@date DATE , @format VARCHAR(20))
RETURNS VARCHAR(30)
AS
BEGIN
DECLARE @date_formated VARCHAR(30)= FORMAT(@date , @format)
RETURN @date_formated
END

SELECT dbo.FormatDate(GETDATE() , 'dddd')
SELECT dbo.FormatDate(GETDATE() , 'dd-MM-yyyy')

------------------------------------------------------------------------
 --23.Create a stored procedure to show the number of books per Category.
------------------------------------------------------------------------
CREATE PROCEDURE GetBooksCountPerCategory
AS
BEGIN
SELECT Category.Id,COUNT(Book.Cat_id) AS [Number of books]
FROM Book RIGHT JOIN Category
ON Book.Cat_id = Category.Id
GROUP BY Category.Id
END


GetBooksCountPerCategory

---------------------------------------------------------------------------------
 --24.Create a stored procedure that will be used in case there is an old manager
 --who has left the floor and a new one becomes his replacement. The
 --procedure should take 3 parameters (old Emp.id, new Emp.id and the
 --floor number) and it will be used to update the floor table.
---------------------------------------------------------------------------------
CREATE PROCEDURE ReplaceManager @old_manager_id INT , @new_manager_id INT, @floor_number INT
AS
BEGIN
UPDATE [Floor]
SET 
	MG_ID = @new_manager_id,
	Hiring_Date = GETDATE()
WHERE Number = @floor_number AND MG_ID = @old_manager_id
END

SELECT * FROM Floor
ReplaceManager 7 , 3 ,1
SELECT * FROM Floor

---------------------------------------------------------------------------------
 --25.Create a view AlexAndCairoEmp that displays Employee data for users
 --who live in Alex or Cairo.
---------------------------------------------------------------------------------
CREATE VIEW AlexAndCairoEmp
AS
SELECT  Fname , Lname , phone ,Email , Address , Floor_no
FROM Employee
WHERE Address IN ('Alex', 'Cairo')


SELECT * FROM AlexAndCairoEmp
---------------------------------------------------------------------------------
--26.create a view "V2" That displays number of books per shelf
---------------------------------------------------------------------------------
CREATE VIEW V2
AS
SELECT Shelf_code , COUNT(*) AS [Number of books]
FROM Book
GROUP BY Shelf_code

SELECT * FROM V2


---------------------------------------------------------------------------------
--27.create a view "V3" That display  the shelf code that have maximum
-- number of  books using the previous view "V2"
---------------------------------------------------------------------------------
CREATE VIEW V3 
AS
SELECT TOP(1) * 
FROM V2
ORDER BY [Number of books] DESC

SELECT * FROM V3


---------------------------------------------------------------------------------
 --28.Create a table named �ReturnedBooks� With the Following Structure :
 --User SSN  |  Book Id  |  Due Date  |  Return Date | fees
 -- then create A trigger that instead of inserting the data of returned book
 --checks if the return date is the due date  or not if not so the user must pay
 --a fee and it will be 20% of the amount that was paid before.
---------------------------------------------------------------------------------

CREATE TABLE ReturnedBooks
(
User_SSN INT,
Book_Id  INT,
Due_Date DATE , 
Return_Date DATE ,
fees REAL ,
--PRIMARY KEY(User_SSN ,Book_Id)
)

ALTER TRIGGER ReturnedBooksTrigger
ON ReturnedBooks 
INSTEAD OF INSERT 
AS 
BEGIN

INSERT INTO ReturnedBooks
SELECT INSERTED.User_SSN , INSERTED.Book_Id , INSERTED.Due_Date , Return_Date , CASE WHEN Return_Date > INSERTED.Due_Date THEN Amount * .2 ELSE 0 END
FROM INSERTED INNER JOIN Borrowing
ON INSERTED.User_SSN = Borrowing.User_ssn AND INSERTED.Book_Id = Borrowing.Book_id

END


INSERT INTO ReturnedBooks (User_SSN,Book_Id,Due_Date,Return_Date)
VALUES (1,3, '2021-02-27' ,'2021-02-28')

INSERT INTO ReturnedBooks (User_SSN,Book_Id,Due_Date,Return_Date)
VALUES (2,3, '2022-03-24' ,'2022-03-24')


---------------------------------------------------------------------------------
 --29.In the Floor table insert new Floor With Number of blocks 2 , employee
 --with SSN = 20 as a manager for this Floor,The start date for this manager
 --is Now. Do what is required if you know that : Mr.Omar Amr(SSN=5)
 --moved to be the manager of the new Floor (id = 7), and they give Mr. Ali
 --Mohamed(his SSN =12) His position .
---------------------------------------------------------------------------------
INSERT INTO Floor
VALUES (7, 2 , 20 , GETDATE())

--old_id : 20  ,new_id : 5, floor_number : 7
--old_id : 5 ,new_id : 12, floor_number : 

ReplaceManager 20 ,5 ,7
ReplaceManager 5 , 12 ,4

SELECT * FROM Floor


-------------------------------------------------------------------------------
--30.Create view name (v_2006_check)  that will display Manager id, Floor
-- Number where he/she works , Number of Blocks and the Hiring Date
-- which must be from the first of March and the May of December
-- 2022.this view will be used to insert data so make sure that the coming
-- new data must match the condition then try to insert this 2 rows and
-- Mention What will happen
-------------------------------------------------------------------------------

CREATE VIEW v_2006_check
AS
SELECT MG_ID , Number , Num_blocks ,Hiring_Date
FROM Floor
WHERE Hiring_Date BETWEEN '2022-03-01' AND '2022-12-31'
WITH CHECK OPTION

SELECT * FROM v_2006_check

INSERT INTO v_2006_check
VALUES 
(2,6,2,'7-8-2023')
--ERROR:: Violation of PRIMARY KEY constraint 'PK_Floor'. Cannot insert duplicate key in object 'dbo.Floor'. The duplicate key value is (6).

--even if you changed the pk
INSERT INTO v_2006_check
VALUES 
(2,8,2,'7-8-2023')
--ERROR:: The attempted insert or update failed because the target view either specifies WITH CHECK OPTION or spans a view that specifies WITH CHECK OPTION and one or more rows resulting from the operation did not qualify under the CHECK OPTION constraint.

INSERT INTO v_2006_check
VALUES 
(4,7,1,' 4-8-2022')
--ERROR:: Violation of PRIMARY KEY constraint 'PK_Floor'. Cannot insert duplicate key in object 'dbo.Floor'. The duplicate key value is (7).


-------------------------------------------------------------------------------
--31.Create a trigger to prevent anyone from Modifying or Delete or Insert in
-- the Employee table ( Display a message for user to tell him that he can�t
-- take any action with this Table)
-------------------------------------------------------------------------------

CREATE TRIGGER DisabelEmployee 
ON Employee
INSTEAD OF INSERT , UPDATE , DELETE 
AS
BEGIN
SELECT 'You can�t take any action with this Table'
END

INSERT INTO Employee (Fname , Lname ,phone)
VALUES ('Noor','Ahmed','1234567')

UPDATE  Employee 
SET Fname = 'Salma'
WHERE Id = 9

DELETE FROM  Employee WHERE Id = 9

-------------------------------------------------------------------------------
 --32.Testing Referential Integrity , Mention What Will Happen When:
-------------------------------------------------------------------------------
 --A. Add a new User Phone Number with User_SSN = 50 in User_Phones Table

 INSERT INTO User_phones
 VALUES (50,'12345')

--The INSERT statement conflicted with the FOREIGN KEY constraint "FK_User_phones_User". The conflict occurred in database "Library", table "dbo.Users", column 'SSN'.

-- This error happen because : there is no user with SSN = 50

-----------------------------------------------------------
 --B. Modify the employee id 20 in the employee table to 21 

DISABLE TRIGGER DisabelEmployee ON Employee

UPDATE Employee
SET Id = 20
WHERE Id = 21

--Cannot update identity column 'Id'.

-----------------------------------------------------------
 --C. Delete the employee with id 1

 DELETE FROM Employee WHERE Id = 1

--The DELETE statement conflicted with the REFERENCE constraint "FK_Borrowing_Employee". The conflict occurred in database "Library", table "dbo.Borrowing", column 'Emp_id'.

--This error happen because  Emp_id is used as a fk in the borrowing table with delete rule No action

-----------------------------------------------------------
 --D. Delete the employee with id 12

  DELETE FROM Employee WHERE Id = 12

--The DELETE statement conflicted with the REFERENCE constraint "FK_Borrowing_Employee". The conflict occurred in database "Library", table "dbo.Borrowing", column 'Emp_id'.

--This error happen because  Emp_id is used as a fk in the borrowing table with delete rule No action

-----------------------------------------------------------
 --E. Create an index on column (Salary) that allows you to cluster the
 --data in table Employee.
 
CREATE CLUSTERED INDEX SalaryIndex
ON Employee(Salary)

--Cannot create more than one clustered index on table 'Employee'. Drop the existing clustered index 'PK_Employee' before creating another.

 CREATE NONCLUSTERED INDEX SalaryIndex 
 ON Employee(Salary)


-------------------------------------------------------------------------------
 -- 33.Try to Create Login With Your Name And give yourself access Only to
 --Employee and Floor tables then allow this login to select and insert data
 --into tables and deny Delete and update (Don't Forget To take screenshot
 --to every step) 
-------------------------------------------------------------------------------

-- Q33 folder

