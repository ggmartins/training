SET NOCOUNT ON;
/*
Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/


SELECT S.Name
FROM Students as S, Students as S2,Friends as F, Packages as P, Packages as P2
WHERE P2.Salary > P.Salary AND
                S.id = P.id AND
                S.id = F.id AND
                F.Friend_ID = S2.id AND
                S2.id = P2.id
ORDER BY P2.Salary ;
                
go
