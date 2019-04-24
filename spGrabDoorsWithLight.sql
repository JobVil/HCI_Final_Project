CREATE PROCEDURE grabDoorsWithLight @LightNum NUMERIC(3, 1)
AS
SELECT Doors.DoorID,
    Doors.FilterTag,
    DoorLights.NumLights,
    DoorTypes.TypeName,
    Doors.Height,
    Doors.Width,
    Doors.Thickness,
    Doors.InteriorExteriorID
FROM Doors, DoorLights, DoorTypes
WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID AND DoorLights.LightNum = @LightNum
GO;