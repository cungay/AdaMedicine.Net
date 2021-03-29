--declare @doctorId INT = NULL
--declare @hospitalId INT = NULL
--declare @unitId INT = 1
--declare @published BIT = 1
--declare @deleted BIT = 0
SELECT
	d.Id,
	d.TitleId,
	d.FirstName,
	d.LastName,
	d.Email,
	d.YearOfBirth,
	d.Languages,
	d.Education,
	d.Experience,
	d.Article,
	d.Memberships,
	d.Courses,
	d.Certifications,
	d.Cv,
	d.ImageUrl,
	d.DisplayOrder,
	d.Published,
	d.Deleted,
	d.CreatedOnUtc,
	d.UpdatedOnUtc
FROM
	dbo.Doctor d (NOLOCK)
INNER JOIN
	dbo.Hospital_Doctor hd (NOLOCK) ON d.Id = hd.DoctorId
WHERE
	--d.Id = ISNULL(@doctorId, d.Id)
	hd.HospitalId = ISNULL(@hospitalId, hd.HospitalId)
AND	hd.UnitId = ISNULL(@unitId, hd.UnitId)
AND d.Published = @published
AND d.Deleted = @deleted