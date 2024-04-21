-- Open the file for reading
local file = io.open('input.txt', 'r')
if not file then
    error("Failed to open file")
end

-- Read the entire content of the file
local content = file:read('*a')

-- Close the file
file:close()

local floor = 0

-- Process each character in the file content
for i = 1, #content do
    local c = content:sub(i, i)
    
    if c == '(' then
        floor = floor + 1
    else
        floor = floor - 1
        if floor == -1 then
            print("position:", i)
            break
        end
    end
end
