--declare @hospitalid INT = null
--declare @categoryId INT = 2
--declare @published BIT = 1
--declare @deleted BIT = 0
SELECT
	c.Id,
	c.CategoryName,
	c.ShortName,
	c.Published,
	c.Deleted,
	c.CreatedOnUtc,
	c.UpdatedOnUtc,
	hsc.DisplayOrder
FROM 
	dbo.StaffCategory c (NOLOCK)
INNER JOIN
	dbo.Hospital_StaffCategory (NOLOCK) hsc ON c.Id = hsc.StaffCategoryId
AND 
	hsc.HospitalId = ISNULL(@hospitalId, hsc.HospitalId)  
GROUP BY
	c.Id,
	c.CategoryName,
	c.ShortName,
	c.Published,
	c.Deleted,
	c.CreatedOnUtc,
	c.UpdatedOnUtc,
	hsc.DisplayOrder
HAVING	
	c.Id = ISNULL(@categoryId, c.Id)
	AND	c.Published = ISNULL(@published, c.published)
	AND c.Deleted = ISNULL(@deleted, c.deleted)
ORDER BY
	hsc.DisplayOrder ASC