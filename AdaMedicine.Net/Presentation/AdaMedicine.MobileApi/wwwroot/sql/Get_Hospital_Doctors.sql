--declare @doctorId INT = NULL
--declare @hospitalId INT = NULL
--declare @unitId INT = NULL
--declare @published BIT = 1
--declare @deleted BIT = 0
SELECT
	d.Id,
	--HospitalId = h.Id,
	--Hospital = h.ShortName,
	--d.TitleId,
	t.Prefix AS Title,
	d.FirstName,
	d.LastName,
	FullName = (t.Prefix + ' ' + d.FirstName + ' ' + d.LastName),
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
--INNER JOIN
--	dbo.Hospital h (NOLOCK) ON h.Id = hd.HospitalId
LEFT JOIN
	dbo.DoctorTitle t (NOLOCK) ON t.Id = d.TitleId
WHERE
	d.Id = ISNULL(@doctorId, d.Id)
AND	hd.HospitalId = ISNULL(@hospitalId, hd.HospitalId)
AND	hd.UnitId = ISNULL(@unitId, hd.UnitId)
AND d.Published = @published
AND d.Deleted = @deleted