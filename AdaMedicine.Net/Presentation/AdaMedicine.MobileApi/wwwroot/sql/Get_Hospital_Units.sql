SELECT 
	c.Id,
	c.SubCategoryId,
	c.CategoryName,
	c.ShortName,
	c.[Description],
	c.ImageUrl,
	c.HtmlContent,
	c.Published,
	c.Deleted,
	c.CreatedOnUtc,
	c.UpdatedOnUtc
FROM 
	dbo.UnitCategory c (NOLOCK)
WHERE 
	c.Id 
IN
(
	SELECT 
		m.CategoryId 
	FROM 
		Hospital_UnitCategory m (NOLOCK) 
	WHERE 
		m.HospitalId = ISNULL(@hospitalId, m.HospitalId)
	GROUP BY
		m.CategoryId
)
AND	c.Id = ISNULL(@categoryId, c.Id)
AND c.Published = ISNULL(@published, 1)
AND c.Deleted = ISNULL(@deleted, 0)
ORDER BY
	c.Id