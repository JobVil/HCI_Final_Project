CREATE PROCEDURE grabAll
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
WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID
GO;