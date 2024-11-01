-- Show first name, last name, and gender of patients whose gender is 'M'
SELECT first_name , last_name ,gender
FROM patients
WHERE gender = 'M'

-- Show first name and last name of patients who does not have allergies. (null)
SELECT first_name , last_name , allergies
FROM patients
WHERE allergies != 'NULL'

-- Show first name of patients that start with the letter 'C'
SELECT first_name
FROM patients
WHERE first_name LIKE 'C%'

-- Show first name and last name of patients that weight within the range of 100 to 120 (inclusive)
SELECT first_name , last_name , weight
FROM patients
WHERE weight between 100 and 120
--the BETWEEN operator in SQL is inclusive, meaning it includes the boundary values specified. 

-- Update the patients table for the allergies column. If the patient's allergies is null then replace it with 'NKA'
UPDATE patients
SET allergies = 'NKA'
WHERE allergies = 'NULL'


--Show first name, last name, and the full province name of each patient.

SELECT first_name , last_name , (SELECT province_name FROM province_names WHERE province_names.province_id = patients.province_id)
FROM patients 

SELECT first_name , last_name , province_name 
FROM  patients INNER JOIN province_names
ON patients.province_id = province_names.province_id




-- Show how many patients have a birth_date with 2010 as the birth year.
SELECT COUNT(*)
FROM patients
WHERE YEAR(birth_date) = 2010

-- Write a query to find list of patients first_name, last_name, and allergies where allergies are not null and are from the city of 'Hamilton'

UPDATE patients
SET allergies = NULL
WHERE allergies = 'NKA'


SELECT first_name, last_name, allergies 
FROM patients
WHERE allergies IS NOT NULL AND city = 'Hamilton'

-- Write a query to find the first_name, last name and birth date of patients who has height greater than 160 and weight greater than 70

SELECT first_name , last_name , birth_date
FROM patients
WHERE height > 160 AND weight > 70

-- Based on the cities that our patients live in, show unique cities that are in province_id 'NS'?

SELECT DISTINCT city
FROM patients 
WHERE province_id = 'NS'

--Show the first_name, last_name, and height of the patient with the greatest height.

SELECT TOP 1 first_name, last_name, height
FROM patients
ORDER BY height DESC

-- Show the patient id and the total number of admissions for patient_id 579.

SELECT patient_id , COUNT(*) 
FROM admissions
GROUP BY patient_id 
HAVING patient_id = 579

-- Show all columns for patients who have one of the following patient_ids: 1,45,534,879,1000
SELECT * 
FROM patients 
WHERE patient_id IN (1,45,534,879,1000)

-- Show all the columns from admissions where the patient was admitted and discharged on the same day.

SELECT * 
FROM admissions
WHERE admission_date = discharge_date

-- Show first name and last name concatinated into one column to show their full name patient.

SELECT first_name +' '+ last_name  AS [Full Name]
FROM patients

SELECT CONCAT(first_name ,' ',last_name ) AS [Full Name]
FROM patients

-- Show patient_id, first_name, last_name from patients whose does not have any records in the admissions table. (Their patient_id does not exist in any admissions.patient_id rows.)

-- All patients exist in the two tables & patients exist in patients tablde & not exist in addimtions table
SELECT patients.patient_id, first_name, last_name 
FROM admissions RIGHT JOIN patients
ON admissions.patient_id = patients.patient_id

EXCEPT
-- All patients exist in the two tables
SELECT patients.patient_id, first_name, last_name 
FROM admissions INNER JOIN patients
ON admissions.patient_id = patients.patient_id

--------------- Tohfa

SELECT patients.patient_id, first_name, last_name , admissions.patient_id
FROM patients LEFT JOIN admissions  -- shared data + patients not eist in addmitions
ON patients.patient_id = admissions.patient_id
WHERE admissions.patient_id IS NULL;

SELECT patient_id first_name , last_name
FROM patients 
WHERE patient_id NOT IN (SELECT patient_id FROM admissions)


SELECT patient_id, first_name, last_name
FROM patients 
WHERE NOT EXISTS (
    SELECT 1
    FROM admissions 
    WHERE patients.patient_id = admissions.patient_id
);

--For every admission, display the patient's full name, their admission diagnosis, and their doctor's full name who diagnosed their problem.

SELECT CONCAT(patients.first_name ,' ' , patients.last_name) AS [Patient Full Name] , diagnosis , CONCAT(doctors.first_name ,' ' , doctors.last_name) AS [Doctor Full Name]
FROM doctors INNER JOIN admissions
ON doctors.doctor_id  = admissions.attending_doctor_id
INNER JOIN patients
ON admissions.patient_id = patients.patient_id

--Show unique birth years from patients and order them by ascending

SELECT DISTINCT YEAR(birth_date)
FROM patients
ORDER BY  YEAR(birth_date) ASC

-- Show all allergies ordered by popularity. Remove NULL values from query.

SELECT allergies , COUNT(*)
FROM patients
GROUP BY allergies
HAVING allergies IS NOT NULL
ORDER BY  COUNT(*) DESC 


-- Show first name, last name and role of every person that is either patient or doctor. The roles are either "Patient" or "Doctor"

SELECT first_name, last_name , 'Patient' AS [Role] FROM patients
UNION
SELECT first_name, last_name , 'Doctor' AS [Role] FROM doctors

-- Show the city and the total number of patients in the city.
--Order from most to least patients and then by city name ascending.

SELECT city , COUNT(*)
FROM patients
GROUP BY city
ORDER BY COUNT(*) DESC , city ASC

-- Show patient_id, diagnosis from admissions. Find patients admitted multiple times for the same diagnosis.

SELECT patient_id , diagnosis 
FROM admissions
GROUP BY patient_id , diagnosis
HAVING COUNT(*) > 1 
ORDER BY patient_id ASC

-- Show the province_id(s), sum of height; where the total sum of its patient's height is greater than or equal to 7,000.
SELECT Province_id , SUM(height)
FROM patients
GROUP BY province_id
HAVING SUM(height) >= 7000 
ORDER BY SUM(height) ASC


-- Show all columns for patient_id 542's most recent admission_date. 

SELECT TOP 1* 
FROM admissions
WHERE patient_id = 542 
ORDER BY admission_date DESC

-- Show all of the days of the month (1-31) and how many admission_dates occurred on that day. Sort by the day with most admissions to least admissions.

SELECT DAY (admission_date) AS [Day] , COUNT(*) AS [Count]
FROM admissions
GROUP BY DAY (admission_date) 
ORDER BY COUNT(*) DESC

-- Show the difference between the largest weight and smallest weight for patients with the last name 'Maroni'
SELECT MAX(weight) - MIN(weight)
FROM patients 
WHERE last_name = 'Maroni'


SELECT (SELECT MAX(weight) FROM patients WHERE last_name = 'Maroni') 
       - (SELECT MIN(weight) FROM patients WHERE last_name = 'Maroni')


-- We want to display each patient's full name in a single column. 
--Their last_name in all upper letters must appear first, then first_name in all lower case letters. 
--Separate the last_name and first_name with a comma. Order the list by the first_name in decending order

SELECT CONCAT( UPPER(last_name),',',LOWER(first_name))
FROM patients
ORDER BY first_name DESC

SELECT CONCAT_WS(',', UPPER(last_name),LOWER(first_name))
FROM patients
ORDER BY first_name DESC


--Show all patient's first_name, last_name, and birth_date who were born in the 1970s decade.
--Sort the list starting from the earliest birth_date.

SELECT first_name, last_name,birth_date
FROM patients
WHERE YEAR(birth_date) >= 1970 AND  YEAR(birth_date) <1980
ORDER BY birth_date 


SELECT first_name, last_name,birth_date
FROM patients
WHERE YEAR(birth_date) BETWEEN  1970 AND 1979
ORDER BY birth_date 

-- Show first_name, last_name, and the total number of admissions attended for each doctor.

SELECT  D.first_name ,D.last_name, COUNT(*)
FROM doctors D INNER JOIN admissions A
ON D.doctor_id = A.attending_doctor_id
GROUP BY D.first_name , D.last_name


-- Display every patient's first_name.
--Order the list by the length of each name and then by alphabetically.

SELECT  first_name
FROM patients
ORDER BY LEN(first_name) , first_name

--Show patient_id, attending_doctor_id, and diagnosis for admissions that match one of the two criteria:
--1. patient_id is an odd number and attending_doctor_id is either 1, 5, or 19.
--2. attending_doctor_id contains a 2 and the length of patient_id is 3 characters.

SELECT patient_id, attending_doctor_id, diagnosis 
FROM admissions
WHERE 
((patient_id % 2) = 1 AND attending_doctor_id IN (1,5,19) ) 
OR
( attending_doctor_id LIKE '%2%' AND LEN(patient_id) = 3)


--Show the total amount of male patients and the total amount of female patients in the patients table.
--Display the two results in the same row.

SELECT DISTINCT (SELECT COUNT(*) FROM patients WHERE gender = 'F') , (SELECT COUNT(*) FROM patients WHERE gender = 'M')
FROM patients


SELECT  CASE WHEN gender = 'M' THEN patient_id END
FROM patients

SELECT  COUNT(CASE WHEN gender = 'M' THEN gender END)  ,  COUNT(CASE WHEN gender = 'F' THEN gender END)
FROM patients

-- Show first and last name, allergies from patients which have allergies to either 'Penicillin' or 'Morphine'. 
--Show results ordered ascending by allergies then by first_name then by last_name.

SELECT first_name , last_name , allergies
FROM patients
WHERE allergies IN ('Penicillin' , 'Morphine')
ORDER BY allergies , first_name , last_name

-- Show unique first names from the patients table which only occurs once in the list.

SELECT first_name
FROM patients
GROUP BY first_name
HAVING COUNT(*) = 1
ORDER BY first_name

-- Show patient_id and first_name from patients where their first_name start and ends with 's' and is at least 6 characters long.

SELECT patient_id , first_name
FROM patients
WHERE first_name LIKE 's%s' AND LEN(first_name)>=6

--Show patient_id, first_name, last_name from patients whos diagnosis is 'Dementia'.

SELECT A.patient_id , first_name , last_name
FROM admissions A INNER JOIN patients P
ON A.patient_id = P.patient_id
WHERE diagnosis = 'Dementia'

-- Display the total amount of patients for each province. Order by descending.

SELECT (SELECT province_name FROM province_names WHERE  province_names.province_id = patients.province_id) , COUNT(*) 
FROM patients 
GROUP BY province_id
ORDER BY COUNT(*) DESC

-- For each doctor, display their id, full name, and the first and last admission date they attended.

SELECT  doctors.doctor_id , CONCAT( first_name , ' ' , last_name), MAX(admission_date)  , MIN( admission_date ) 
FROM admissions  INNER JOIN doctors
ON admissions.attending_doctor_id = doctors.doctor_id
GROUP BY doctors.doctor_id , first_name , last_name
ORDER BY doctors.doctor_id


-- Show all of the patients grouped into weight groups.
--Show the total amount of patients in each weight group.
--Order the list by the weight group decending.

SELECT COUNT(*) , (weight / 10) * 10  
FROM patients
GROUP BY (weight / 10) * 10 
ORDER BY  (weight / 10) * 10  DESC


--Show patient_id, weight, height, isObese from the patients table.

--Display isObese as a boolean 0 or 1.

--Obese is defined as weight(kg)/(height(m)2) >= 30.

--weight is in units kg.

--height is in units cm.

SELECT patient_id, 
       weight, 
	   height ,
       CASE WHEN (weight/(POWER(height/100,2))) >= 30 THEN 1 
	   ELSE 0 
	   END  AS isObese
FROM patients


SELECT
    patient_id,
    weight,
    height,
    CASE
        WHEN (weight / (POWER(height / 100.0, 2))) >= 30 THEN 1
        ELSE 0
    END AS isObese
FROM patients;


-- Show patient_id, first_name, last_name, and attending doctor's specialty.
-- Show only the patients who has a diagnosis as 'Epilepsy' and the doctor's first name is 'Lisa'

SELECT patients.patient_id, patients.first_name, patients.last_name,specialty
FROM admissions INNER JOIN doctors
ON admissions.attending_doctor_id = doctors.doctor_id 
INNER JOIN patients
ON patients.patient_id = admissions.patient_id
WHERE diagnosis = 'Epilepsy' AND doctors.first_name = 'Lisa'


-- All patients who have gone through admissions, can see their medical documents on our site. 
--Those patients are given a temporary password after their first admission. Show the patient_id and temp_password.

--The password must be the following, in order:
--1. patient_id
--2. the numerical length of patient's last_name
--3. year of patient's birth_date

SELECT DISTINCT admissions.patient_id , CONCAT(patients.patient_id ,LEN(patients.last_name),YEAR(birth_date) ) AS [Password]
FROM admissions INNER JOIN patients
ON admissions.patient_id = patients.patient_id


--Each admission costs $50 for patients without insurance, and $10 for patients with insurance. All patients with an even patient_id have insurance.
--Give each patient a 'Yes' if they have insurance, and a 'No' if they don't have insurance. Add up the admission_total cost for each has_insurance group.

SELECT CASE WHEN patient_id%2 = 1 THEN 'YES'  ELSE 'NO' END AS [Has insurance] , CASE WHEN patient_id%2 = 1 THEN COUNT(*)*10  ELSE COUNT(*)*50 END AS [admission_total cost]
FROM admissions
GROUP BY patient_id%2 


SELECT 'NO' AS [Has insurance] , COUNT(*) * 50 AS [admission_total cost]
FROM admissions
WHERE patient_id % 2 = 1

UNION

SELECT 'YES' , COUNT(*) * 10
FROM admissions
WHERE patient_id % 2 = 0


-- Show the provinces that has more patients identified as 'M' than 'F'. Must only show full province_name

SELECT * FROM province_names

SELECT province_name   , SUM(CASE WHEN gender = 'M' THEN 1 ELSE 0 END) , SUM(CASE WHEN gender = 'F' THEN 1 ELSE 0 END)
FROM patients INNER JOIN province_names
ON patients.province_id = province_names.province_id
GROUP BY province_name
HAVING SUM(CASE WHEN gender = 'M' THEN 1 ELSE 0 END) > SUM(CASE WHEN gender = 'F' THEN 1 ELSE 0 END)


--We are looking for a specific patient. Pull all columns for the patient who matches the following criteria:
--- First_name contains an 'r' after the first two letters.
--- Identifies their gender as 'F'
--- Born in February, May, or December  2 ,5,12
--- Their weight would be between 60kg and 80kg
--- Their patient_id is an odd number
--- They are from the city 'Kingston'



SELECT *
FROM patients
WHERE first_name LIKE '__r%' AND gender = 'F' AND MONTH(birth_date) IN (2,5,12) AND weight BETWEEN 60 AND 80
AND patient_id % 2 = 1 AND city = 'Kingston'


-- Show the percent of patients that have 'M' as their gender. Round the answer to the nearest hundreth number and in percent form.

SELECT CONCAT (ROUND(COUNT(*)* 1.0 / (SELECT COUNT(*) FROM patients ) * 100 , 2) ,'%')
FROM patients 
WHERE gender = 'M'



SELECT 
    CONVERT(VARCHAR, 
        ROUND(
            (COUNT(CASE WHEN gender = 'M' THEN 1 ELSE NULL END) * 100.0) / 
            (SELECT COUNT(*) FROM patients), 
            2
        )
    ) + '%' AS percent_male
FROM patients;


-- Sort the province names in ascending order in such a way that the province 'Ontario' is always on top.
SELECT province_name 
FROM province_names
ORDER BY CASE WHEN province_name = 'Ontario' THEN 0  ELSE 1 END , province_name ASC
--given the highest priority (0) in the sort order, effectively placing it at the top.


-- We need a breakdown for the total amount of admissions each doctor has started each year.
--Show the doctor_id, doctor_full_name, specialty, year, total_admissions for that year.

SELECT attending_doctor_id ,CONCAT(first_name , ' ' ,last_name), specialty , YEAR(admission_date) , COUNT(*)
FROM admissions INNER JOIN doctors 
ON admissions.attending_doctor_id = doctors.doctor_id
GROUP BY attending_doctor_id , YEAR(admission_date) , CONCAT(first_name , ' ' ,last_name), specialty 
ORDER BY attending_doctor_id



--Display patient's full name,
--height in the units feet rounded to 1 decimal,
--weight in the unit pounds rounded to 0 decimals,
--birth_date,
--gender non abbreviated.

--Convert CM to feet by dividing by 30.48.
--Convert KG to pounds by multiplying by 2.205.

SELECT CONCAT(first_name,' ',last_name) AS [Full name] 
,ROUND( height/30.48 ,1) AS [Height in feet] 
,ROUND( weight * 2.205,0) AS [Weight in pounds]
, birth_date 
, CASE WHEN gender = 'F' THEN 'Female' 
       WHEN gender = 'M' THEN 'Male' 
  END AS [Gender]
FROM patients 


-- For each day display the total amount of admissions on that day. Display the amount changed from the previous date.
-- LAG 



