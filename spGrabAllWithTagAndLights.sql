CREATE PROCEDURE grabAllWithTagAndLights @FilterTag VARCHAR(24) CHARACTER SET utf8, @LightNum NUMERIC(3, 1)
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
WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID AND (Doors.FilterTag = @FilterTag OR DoorTypes.FilterTag) AND DoorLights.LightNum = @LightNum
GO;