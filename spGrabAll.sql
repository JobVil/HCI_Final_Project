CREATE FUNCTION grabAll
RETURNS TABLE (
    DoorID VARCHAR(24),
    Description VARCHAR(35),
    NumLights NUMERIC(3,1), 
    TypeName VARCHAR(3),
    TypesFilterTag VARCHAR(24),
    Height NUMERIC(3,1),
    Width NUMERIC(4,1),
    Thickness NUMERIC (2,1),
    InteriorExteriorID INT,
    FilterTag VARCHAR(24)
) AS $$
BEGIN
    SELECT Doors.DoorID,
        Doors.Description,
        DoorLights.NumLights,
        DoorTypes.TypeName,
        DoorTypes.FilterTag,
        Doors.Height,
        Doors.Width,
        Doors.Thickness,
        Doors.InteriorExteriorID,
        Doors.FilterTag
    FROM Doors, DoorLights, DoorTypes
    WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID
END;
LANGUAGE 'plpgsql';