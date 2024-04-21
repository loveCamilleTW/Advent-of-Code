-- Open the file for reading
local file = io.open('input.txt', 'r')
if not file then
    error("Failed to open file")
end

-- Read the entire content of the file
local content = file:read('*a')

-- Close the file
file:close()

local sum = 0

for line in string.gmatch(content, "[^\r\n]+") do
    for length, width, height in string.gmatch(line, "(%d+)x(%d+)x(%d+)") do
        local surfaceArea = 2 * (length * width + width * height + height * length)
        local extra = math.min(length * width, width * height, height * length);

        sum = sum + surfaceArea + extra
    end
end

print('sum:', sum)