--declare @hospitalId INT = 1
--declare @categoryId INT = NULL
--declare @published BIT = 1
--declare @deleted BIT = 0
SELECT 
	s.Id,
	s.StaffName,
	s.YearOfBirth,
	s.Languages,
	s.Education,
	s.Experience,
	s.Article,
	s.Memberships,
	s.Courses,
	s.Certifications,
	s.ImageUrl,
	s.Published,
	s.Deleted,
	s.CreatedOnUtc,
	s.UpdatedOnUtc
FROM 
	dbo.Staff s (NOLOCK)
INNER JOIN
	dbo.Hospital_Staff hs (NOLOCK) ON s.Id = hs.StaffId
WHERE
	hs.HospitalId = ISNULL(@hospitalId, hs.HospitalId)
AND	hs.StaffCategoryId = ISNULL(@categoryId, hs.StaffCategoryId)
AND s.Published = @published
AND s.Deleted = @deleted
