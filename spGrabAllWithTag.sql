CREATE PROCEDURE grabAllWithTag @FilterTag VARCHAR(24) CHARACTER SET utf8
AS
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
WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID AND (Doors.FilterTag = @FilterTag OR DoorTypes.FilterTag)
GO;